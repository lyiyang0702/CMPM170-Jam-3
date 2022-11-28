using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

//Script From Running away from battle
//Probably Do not need it in the end game, but keep as a place holder for now.
public class RunFromBattle : MonoBehaviour {
	//Get the number the player set in the Unity Scene 
	[SerializeField]
	private float runnningChance;
	//When the player calls the script, the function will call a random value between 0 and 1.
	//If the number is less than the running Chance, the player successfully goes back to the Town scene.
	//Else, the game continues to the next turn. 
	public void tryRunning() {
		float randomNumber = Random.value;
		if (randomNumber < this.runnningChance) {
			SceneManager.LoadScene ("Town");
		} else {
			GameObject.Find("TurnSystem").GetComponent<TurnSystem> ().nextTurn ();
		}
	}
}
