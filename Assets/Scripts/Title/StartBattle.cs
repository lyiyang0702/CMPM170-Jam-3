using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartBattle : MonoBehaviour {

	//Start Function
	//Creates the party when the game is loaded.
	//Makes the party invisible, because they are actually on the title screen.
	void Start () {
		DontDestroyOnLoad (this.gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;

		this.gameObject.SetActive (false);
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		//Error Check Statement to avoid crashes
		//If Scene is the title screen 
		if (scene.name == "Title") {
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (this.gameObject);
		} else {
			//this.gameObject.SetActive(scene.name == "Battle");
			this.gameObject.SetActive (true);
		}
	}

}
