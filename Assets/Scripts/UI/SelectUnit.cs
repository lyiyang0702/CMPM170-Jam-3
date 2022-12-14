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
		GameObject[] descriptions = GameObject.FindGameObjectsWithTag ("ActionText");
		foreach (GameObject x in descriptions) {
				x.SetActive(false);
		}
	}

	//Select attack based off of the number. 
	//The integer determines which attack the player chooses. 
	public void selectAttack(int Attacktype) {
		this.currentUnit.GetComponent<PlayerUnitAction> ().selectAttack (Attacktype);
		GameObject[] List = GameObject.FindGameObjectsWithTag ("ActionText");
		foreach (GameObject y in List) {
				y.SetActive(false);
		}

		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (true);
	}

	public void attackEnemyTarget(GameObject target) {
		GameObject[] Zeta = GameObject.FindGameObjectsWithTag ("ActionText");
		foreach (GameObject z in Zeta) {
				z.SetActive(false);
		}

		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (false);
		GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag ("TotalHealth");
		Debug.Log("Attack Prefab YOLOOOO");
		this.currentUnit.GetComponent<PlayerUnitAction>().act (possibleTargets[0]);
	}

	public int returnElement() {
		int varElement = this.currentUnit.GetComponent<UnitStats>().element;
		Debug.Log("THe current Element unit's element is" + varElement);
		return varElement;
	}
}
