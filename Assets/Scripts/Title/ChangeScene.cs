using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


//Class that determines which scene to change when the start button is clicked
public class ChangeScene : MonoBehaviour {

	//Loads the next scene from the possible scenes of the game.
	public void loadNextScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}
