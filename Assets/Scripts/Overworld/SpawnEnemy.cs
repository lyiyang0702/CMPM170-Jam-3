using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

//Overworld Script.
//When Player object collides with 
public class SpawnEnemy : MonoBehaviour {

	//Serialize an preset enemy encounter so the script can spawn them.
	//Make sure to set the spawning to false in the town area.
	[SerializeField]
	private GameObject enemyEncounterPrefab;

	private bool spawning = false;

	//On Start of the game, keep the instatiation loaded
	//And make the object active when on Battle scene.
	void Start() {
		DontDestroyOnLoad (this.gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	//When the scene transistions into battle, the game loads the enemy in Battle.
	//After that, it will go back a scene to the "Town Scene" and destroy the spawner to avoid an infinite loop.
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Battle") {
			if (this.spawning) {
				Instantiate (enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (this.gameObject);
		}
	}

	//If enemy tile collides w/ Player object
	//Transition into Battle Scene.
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			this.spawning = true;
			SceneManager.LoadScene ("Battle");
		}
	}
}
