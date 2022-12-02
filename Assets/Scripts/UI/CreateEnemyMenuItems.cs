using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//CreateEnemyMenuItems shows the enemy icons when they are present in the field.
//Might need to tweak or get rid of, as attacks just directly hit any enemy. 
public class CreateEnemyMenuItems : MonoBehaviour {
	//Initialized Values set by user.
	[SerializeField]
	private GameObject targetEnemyUnitPrefab;

	//Icon of the targetted enemy.
	[SerializeField]
	private Sprite menuItemSprite;

	[SerializeField]
	private Vector2 initialPosition, itemDimensions;

	[SerializeField]
	private KillEnemy killEnemyScript;

	//When the scene starts, the Script looks for any tags with the Enemy Tag.
	//It then adds to an array of Game Objects of Enemy Units.
	void Awake () {
		GameObject enemyUnitsMenu = GameObject.Find ("EnemyUnitsMenu");
		//Find all possible targettable enemies.
		GameObject[] existingItems = GameObject.FindGameObjectsWithTag ("TotalHealth");
		
		//GameObject[] Test = GameObject.FindGameObjectsWithTag ("TotalHealth");
		
		Vector2 nextPosition = new Vector2 (this.initialPosition.x + (existingItems.Length * this.itemDimensions.x), this.initialPosition.y + 100);
		//If there is more than 1 enemy, move the Position and the scale of the icons.
		GameObject targetEnemyUnit = Instantiate (this.targetEnemyUnitPrefab, enemyUnitsMenu.transform) as GameObject;
		targetEnemyUnit.name = "Target" + this.gameObject.name;	
		targetEnemyUnit.transform.localPosition = nextPosition;
		targetEnemyUnit.transform.localScale = new Vector2 (2f, 1f);
		//If the Mouse is over the enemy icon, on click attack the selected enemy.
		targetEnemyUnit.GetComponent<Button> ().onClick.AddListener (() => 
			selectEnemyTarget());
		targetEnemyUnit.GetComponent<Image> ().sprite = this.menuItemSprite;
		//Kill the icons after the attack.
		killEnemyScript.menuItem = targetEnemyUnit;
	}

	//Attacks whichever enemy the player clicks on.
	//E.g. If Player 1 attacks Enemy 1, the partyData first looks through the PlayerParty Object.
	//It then finds the specific Unit initializing the attack and the targetted enemy.
	public void selectEnemyTarget() {
		GameObject partyData = GameObject.Find ("PlayerParty");
		partyData.GetComponent<SelectUnit> ().attackEnemyTarget (this.gameObject);
	}

}
