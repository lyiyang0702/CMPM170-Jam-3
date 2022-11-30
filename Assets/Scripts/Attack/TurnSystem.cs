using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


//Turn System Script is the 
public class TurnSystem : MonoBehaviour {

	private List<UnitStats> unitsStats;

	private GameObject playerParty;

	public GameObject enemyEncounter;

	[SerializeField]
	private GameObject actionsMenu, enemyUnitsMenu;

	void Start() {
		this.playerParty = GameObject.Find ("PlayerParty");
		//Add Players and Enemy Units to a giant list of stats.
		//Once all units have been passed into the list, the list is sorted in order according to speed.
		unitsStats = new List<UnitStats> ();
		GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
		foreach (GameObject playerUnit in playerUnits) {
			UnitStats currentUnitStats = playerUnit.GetComponent<UnitStats> ();
			currentUnitStats.calculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
		}
		GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
		foreach (GameObject enemyUnit in enemyUnits) {
			UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats> ();
			currentUnitStats.calculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
		}

		//Stats are sorted here.
		unitsStats.Sort ();

		//Make sure UI is invisible.
		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (false);

		//Call next turn.
		this.nextTurn ();
	}

	//Next turn determines when next
	public void nextTurn() {
		//FIXME
		//We probably don't need this area because we are not defeating all enemies as a win condition
		//Or Lose when all players are dead.
		GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag ("EnemyUnit");
		if (remainingEnemyUnits.Length == 0) {
			this.enemyEncounter.GetComponent<CollectReward> ().collectReward ();
			SceneManager.LoadScene ("Town");
		}

		GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		if (remainingPlayerUnits.Length == 0) {
			SceneManager.LoadScene("Title");
		}


		UnitStats currentUnitStats = unitsStats [0];
		unitsStats.Remove (currentUnitStats);
		//If the current Unit is alive, calculate who will go next.
		if (!currentUnitStats.isDead ()) {
			GameObject currentUnit = currentUnitStats.gameObject;

			currentUnitStats.calculateNextActTurn (currentUnitStats.nextActTurn);
			unitsStats.Add (currentUnitStats);
			unitsStats.Sort ();
			//See if the Unit is a Player Unit.
			//If so, make the player choose the actions.
			//Else, the AI chooses the action.
			if (currentUnit.tag == "PlayerUnit") {
				this.playerParty.GetComponent<SelectUnit> ().selectCurrentUnit (currentUnit.gameObject);
			} else {
				currentUnit.GetComponent<EnemyUnitAction> ().act ();
			}
		} else {
			//Go to next unit
			this.nextTurn ();
		}
	}
}
