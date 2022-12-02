using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//Player Actions

//VERY IMPORTANT SCRIPT!
//If we would want to add more skills we would have to make sure we add it to the script or
//the skill would not be recognized as a unique skill
public class PlayerUnitAction : MonoBehaviour {

	[SerializeField]
	private GameObject physicalAttack;

	[SerializeField]
	private GameObject magicalAttack;

	[SerializeField]
	private GameObject elementAttack;

	[SerializeField]
	private GameObject elementAttack2;

	[SerializeField]
	private GameObject elementAttack3;

	private GameObject currentAttack;

	[SerializeField]
	private Sprite faceSprite;

	//Initiate the player's default attack.
	void Awake () {
		this.physicalAttack = Instantiate (this.physicalAttack, this.transform) as GameObject;
		this.magicalAttack = Instantiate (this.magicalAttack, this.transform) as GameObject;
	    this.elementAttack = Instantiate (this.elementAttack, this.transform) as GameObject;
		this.elementAttack2 = Instantiate (this.elementAttack2, this.transform) as GameObject;
		this.elementAttack3 = Instantiate (this.elementAttack3, this.transform) as GameObject;

		this.physicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;
		this.magicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;
		this.elementAttack.GetComponent<AttackTarget> ().owner = this.gameObject;
		this.elementAttack2.GetComponent<AttackTarget> ().owner = this.gameObject;
		this.elementAttack3.GetComponent<AttackTarget> ().owner = this.gameObject;

		this.currentAttack = this.physicalAttack;
	}

	//Selecting the attack and check to see if the player choose a magic or physical attack.
	public void selectAttack(int physical) {
		if (physical == 0){
			Debug.Log("Attack is Physical");
			this.currentAttack = this.physicalAttack;
		}
		else if (physical == 1){
			this.currentAttack = this.magicalAttack;
			Debug.Log("Attack is Magic");
		}
		else if (physical == 2){
			this.currentAttack = this.elementAttack;
			Debug.Log("Attack is Element");
		}
		else if (physical == 3){
			this.currentAttack = this.elementAttack2;
			Debug.Log("Attack is Element2");
		}
		else if (physical == 4){
			this.currentAttack = this.elementAttack3;
			Debug.Log("Attack is Element3");
		}
		/*
		this.currentAttack = (physical) ? this.physicalAttack : this.magicalAttack;
		*/
	}

	//Initialize the attack and calculate damage.
	public void act(GameObject target) {
		this.currentAttack.GetComponent<AttackTarget> ().hit (target, false);
	}

	//Update the HUD. Make invisible icons appear.
	public void updateHUD() {
		GameObject playerUnitFace = GameObject.Find ("PlayerUnitFace") as GameObject;
		playerUnitFace.GetComponent<Image> ().sprite = this.faceSprite;

		GameObject playerUnitManaBar = GameObject.Find ("PlayerUnitManaBar") as GameObject;
		playerUnitManaBar.GetComponent<ShowUnitMana> ().changeUnit (this.gameObject);

		GameObject playerUnitMana = GameObject.Find("PlayerUnitMana") as GameObject;
    	playerUnitMana.GetComponent<Text>().text  = this.GetComponent<UnitStats> ().mana.ToString();

	}
}
