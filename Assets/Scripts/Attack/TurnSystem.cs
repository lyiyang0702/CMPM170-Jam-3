using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


//Turn System Script is the 
public class TurnSystem : MonoBehaviour {

	private float currHP;
	private int RemainingTurns;
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

		foreach( var x in unitsStats) {
			Debug.Log( x.ToString());
			RemainingTurns ++;
		}

		RemainingTurns = RemainingTurns * 5;
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
		
		Debug.Log("Remaing Turns = " + RemainingTurns);
		GameObject[] FanBaseBar = GameObject.FindGameObjectsWithTag ("TotalHealth");
		
		//If the Opponent Band Knocks out
		if (FanBaseBar.Length == 0) {
			Debug.Log("Game Over, Player Lost");
			SceneManager.LoadScene("Title");
		}

		else{
			GameObject FanBar = GameObject.Find("FanBar");
			UnitStats CurrentHealth = FanBar.GetComponent<UnitStats> ();
			currHP = CurrentHealth.returnHealth();
			Debug.Log("Right now the fanbase is " + currHP);

			GameObject FBUI = GameObject.Find("FanBaseBar");
			Vector2 objectScale = FBUI.transform.localScale;
			FBUI.transform.localScale = new Vector2(290 * (currHP/200) ,  objectScale.y);
			//FIXME
			//We probably don't need this area because we are not defeating all enemies as a win condition
			//Or Lose when all players are dead.
			if (currHP >= 400) {
				Debug.Log("VICTORY! Player wins!");
				this.enemyEncounter.GetComponent<CollectReward> ().collectReward ();
				SceneManager.LoadScene ("Town");
			}

			

			//If One band does not get a knock out before 5 turns, see which team has more points.
			if(RemainingTurns == 0){
				if(currHP >= 200){
					Debug.Log("PLAYER WINSSSSS!!!!");
				}
				else if(currHP < 200){
					Debug.Log("GAME OVERRRRR!!!!");
				}
			}
		}
		UnitStats currentUnitStats = unitsStats [0];
		unitsStats.Remove (currentUnitStats);
		//If the current Unit is alive, calculate who will go next.

		

		if (!currentUnitStats.isDead () && !currentUnitStats.isNotPlayable() && !currentUnitStats.isStuned()) {
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
			RemainingTurns--;
		} else {
			//Go to next unit
			Debug.Log("The Enemy is Stunned and can't move!");
			RemainingTurns--;
			this.nextTurn ();
			
		}
	}
}
