using UnityEngine;
using System.Collections;

//Collect Reward Grants EXP to all living Players in the case of level up.
//Probably Do not need it in the grand scheme of things. 
public class CollectReward : MonoBehaviour {
	//Get the private field of the number of EXP the player gets in the 
	[SerializeField]
	private float experience;

	//Find the GameObject of the 
	public void Start() {
		GameObject turnSystem = GameObject.Find ("TurnSystem");
		turnSystem.GetComponent<TurnSystem> ().enemyEncounter = this.gameObject;
	}

	//Find all players alive by first searching through the Player game objects
	//Then seeing if they are alive or not. 
	//If they are alive, add them to the list.
	//Break the total EXP with the number of players alive, then give to all the players alive.
	public void collectReward() {
		GameObject[] livingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		float experiencePerUnit = this.experience / (float)livingPlayerUnits.Length;
		foreach (GameObject playerUnit in livingPlayerUnits) {
			playerUnit.GetComponent<UnitStats> ().receiveExperience (experiencePerUnit);
		}
		//Destroy the game object from the scene. 
		Destroy (this.gameObject);
	}
}
