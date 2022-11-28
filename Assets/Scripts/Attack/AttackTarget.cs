using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour {

	//GameObject owner is the player unit.
	public GameObject owner;

	//The serialized fields determine what the player does depending on the move
	//What animation does the character play?
	[SerializeField]
	private string attackAnimation;

	//Is the attack magic?
	[SerializeField]
	private bool magicAttack;

	//How much MP?
	[SerializeField]
	private float manaCost;

	//Determining the numbers for defense and attack.
	[SerializeField]
	private float minAttackMultiplier;

	[SerializeField]
	private float maxAttackMultiplier;

	[SerializeField]
	private float minDefenseMultiplier;

	[SerializeField]
	private float maxDefenseMultiplier;
	
	//Function hit.
	//Targets an enemy unit and 

	//Possibly get rid of the targetStats and only take the attack portion (E.g. Get rid of Defence)
	//FIX ME
	public void hit(GameObject target) {
		//Get Stats from player and Enemy
		UnitStats ownerStats = this.owner.GetComponent<UnitStats> ();
		UnitStats targetStats = target.GetComponent<UnitStats> ();
		//If the player has enough mana
		if (ownerStats.mana >= this.manaCost) {
			//This float determines the range of numbers the attack could deal. 
			float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
			//Is the attack magic?
			// - If true : Attack using Magic stat.
			// - If false: Attack using Attack stat.
			float damage = (this.magicAttack) ? attackMultiplier * ownerStats.magic : attackMultiplier * ownerStats.attack;

			//This float determines the amount of damage is defend.
			float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
			
			//Final Damage of the attack.
			damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

			//Call Animator and play attack animation.
			this.owner.GetComponent<Animator> ().Play (this.attackAnimation);
			//Enemy Receives Damage
			targetStats.receiveDamage (damage);
			
			//Subtract MP from Player
			ownerStats.mana -= this.manaCost;
		}
	}
}
