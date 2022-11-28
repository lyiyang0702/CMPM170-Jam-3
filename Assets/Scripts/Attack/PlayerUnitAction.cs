﻿using UnityEngine;
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

	private GameObject currentAttack;

	[SerializeField]
	private Sprite faceSprite;

	//Initiate the player's default attack.
	void Awake () {
		this.physicalAttack = Instantiate (this.physicalAttack, this.transform) as GameObject;
		this.magicalAttack = Instantiate (this.magicalAttack, this.transform) as GameObject;

		this.physicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;
		this.magicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;

		this.currentAttack = this.physicalAttack;
	}

	//Selecting the attack and check to see if the player choose a magic or physical attack.
	public void selectAttack(bool physical) {
		this.currentAttack = (physical) ? this.physicalAttack : this.magicalAttack;
	}

	//Initialize the attack and calculate damage.
	public void act(GameObject target) {
		this.currentAttack.GetComponent<AttackTarget> ().hit (target);
	}

	//Update the HUD. Make invisible icons appear.
	public void updateHUD() {
		GameObject playerUnitFace = GameObject.Find ("PlayerUnitFace") as GameObject;
		playerUnitFace.GetComponent<Image> ().sprite = this.faceSprite;

		GameObject playerUnitHealthBar = GameObject.Find ("PlayerUnitHealthBar") as GameObject;
		playerUnitHealthBar.GetComponent<ShowUnitHealth> ().changeUnit (this.gameObject);

		GameObject playerUnitManaBar = GameObject.Find ("PlayerUnitManaBar") as GameObject;
		playerUnitManaBar.GetComponent<ShowUnitMana> ().changeUnit (this.gameObject);
	}
}
