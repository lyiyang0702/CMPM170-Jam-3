using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectUnit : MonoBehaviour {

	private GameObject currentUnit;

	private GameObject actionsMenu, enemyUnitsMenu;

	void Awake() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Battle") {
			this.actionsMenu = GameObject.Find ("ActionsMenu");
			this.enemyUnitsMenu = GameObject.Find ("EnemyUnitsMenu");
		}
	}

	public void selectCurrentUnit(GameObject unit) {
		this.currentUnit = unit;

		this.actionsMenu.SetActive (true);

		this.currentUnit.GetComponent<PlayerUnitAction> ().updateHUD ();
	}

	//Select attack based off of the number. 
	//The integer determines which attack the player chooses. 
	public void selectAttack(int Attacktype) {
		this.currentUnit.GetComponent<PlayerUnitAction> ().selectAttack (Attacktype);

		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (true);
	}

	public void attackEnemyTarget(GameObject target) {
		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (false);
		GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag ("TotalHealth");
		Debug.Log("Attack Prefab YOLOOOO");
		this.currentUnit.GetComponent<PlayerUnitAction>().act (possibleTargets[0]);
	}
}
