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
	
	[SerializeField]
	private int ElementChecker;
	
	[SerializeField]
	private int ElementTier;
	
	//Function hit.
	//Targets an enemy unit and 

	//Possibly get rid of the targetStats and only take the attack portion (E.g. Get rid of Defence)
	//FIX ME
	public void hit(GameObject target, bool isEnemy) {
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

			
			

			if(!isEnemy){
				Debug.Log("Player Attacks!");
				damage = damage *-1;

				//Buff Checks. See if certain attack states are true for the unit.
				//Check if Ember Song is Played.
				if(ownerStats.emberEffect() == true){
					damage = damage - 30;
				}

				if(ownerStats.HurricaneVortex > 0){
					Debug.Log("HurricaneVortex Lvl " + ownerStats.HurricaneVortex);
					damage = damage - (10 * ownerStats.HurricaneVortex);
					ownerStats.HurricaneVortex++;
				}
				
				//List of Fire Magic Attacks.
				if(ElementChecker == 1){
					Debug.Log("The Player Used Fire Magic");
					if(ElementTier == 1){
						//Fire Fist: Gets Stronger the More times you use it. 
						Debug.Log("The Player Used Fire Fist");
						damage = attackMultiplier * 25 * (1 + ownerStats.returnFlameFist()) * -1;
						ownerStats.FlameFistBuff++;
					}
					if(ElementTier == 2){
						//Gives the player an extra 30 damage for each reaccuring attack.
						ownerStats.EmberSong = true;
						Debug.Log("The Player Used EmberSong");
					}
					if(ElementTier == 3){
						Debug.Log("The Player Used Onibi Homura");
						//Flaming Power: Triples the Unit's Physical Attack Stat for the rest of the performance
						damage = 0;
						ownerStats.attack = ownerStats.attack * 3;
					}
				}
				//List of Wind Magic Attacks.
				else if(ElementChecker == 2){
					Debug.Log("The Player Used Wind Magic");
					if(ElementTier == 1){
						//Gale Melody: Has a cance of striking the enemy's weakness and deal 3 times the amount of damage.
						//However, it is prone to missing.
						Debug.Log("The Player Used Gale Melody");
						float randomNumber = Random.value;
						if (randomNumber < 0.7) {
							Debug.Log("Critical HIT!");
							damage = damage * 3;
						} 
						else {
							Debug.Log("The Attack Missed!");
							damage = 0;
						}
					}
					if(ElementTier == 2){
						//Hurricane Vortex: Creates a strong tornade that deals additional damage.
						//The longer you leave it out the stronger the tornado gets. 
						Debug.Log("The Player Used Hurricane Vortex");
						if(ownerStats.HurricaneVortex == 0){
							ownerStats.HurricaneVortex = 1;
						}
						else{
							Debug.Log("The Vortex is Amplified!");
							ownerStats.HurricaneVortex++;
						}
						
					}
					if(ElementTier == 3){
						Debug.Log("The Player Used Tatsumaki Storm");
						//Shoots 5 - 10 tornadoes.
						//
						float randomNumber = Random.value;
						if (randomNumber > 0.9) {
							Debug.Log("10 tornadoes");
							damage = (damage / 2) * 10; 
						} 
						else if (randomNumber > 0.75 && randomNumber < 0.9) {
							Debug.Log("9 tornadoes!");
							damage = (damage / 2) * 9; 
						} 
						else if (randomNumber > 0.55 && randomNumber < 0.75) {
							Debug.Log("8 tornadoes");
							damage = (damage / 2) * 8;
						} 
						else if (randomNumber > 0.35 && randomNumber < 0.55) {
							Debug.Log("7 tornadoes!");
							damage = (damage / 2) * 7; 
						} 
						else if (randomNumber > 0.25 && randomNumber < 0.35) {
							Debug.Log("6 tornadoes!");
							damage = (damage / 2) * 6; 
						} 
						else {
							Debug.Log("5 tornadoes!");
							damage = (damage / 2) * 5 ; 
						} 
						
					}
				
					
				}
				//List of Ice Magic Attacks.
				else if(ElementChecker == 3){
					Debug.Log("The Player Used Ice Magic");
					if(ElementTier == 1){
						//Snowflake Magic: Increases Magic Stat by 10;
						Debug.Log("The Player Used Snowflake Magic");
						ownerStats.magic = ownerStats.magic + 10;
					}
					if(ElementTier == 2){
						//Icicle Lance: Can Deal up to 2.5 times the damage.
						float randomNumber = Random.value;
						damage = (2.5f - randomNumber) * damage;
					}

					if(ElementTier == 3){
						//Hell Fubuki: Targets All enemy units.
						//50% of chance stunning enemies. 
						Debug.Log("The Player Used Hell Fubuki");

						GameObject[] possibleEnemies = GameObject.FindGameObjectsWithTag ("EnemyUnit");
						Debug.Log("Length of enemies" + possibleEnemies.Length);
						foreach (GameObject enemyUnit in possibleEnemies) {
							UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats> ();
							float randomNumber = Random.value;
							Debug.Log("The Enemy is currently " + currentUnitStats.name);
							if (randomNumber < 0.5) {
								Debug.Log("The Enemy is Frozen!");
								currentUnitStats.stun = true;
								damage = 0;
							} 
							else {
								Debug.Log("The Enemy is not Frozen!");
								damage = 0;
							}

						}
					}
				}
				//List of Water Magic Attacks.
				else if(ElementChecker == 4){
					Debug.Log("The Player Used Water Magic");
					if(ElementTier == 1){
						//Water Needle: Deals 30 Flat Damage.
						damage = -30;
					
					}
					if(ElementTier == 2){
						//Wave Striker: Has a base damage of 25. Has a random chance of 
						//Maximum 125. Has a very small percent chance of missing.
						float randomNumber = Random.value;
						if (randomNumber > 0.8) {
							Debug.Log("Wave Striker Hit 5 times!");
							damage = -125;
						} 
						else if (randomNumber > 0.6 && randomNumber < 0.8) {
							Debug.Log("Wave Striker Hit 4 times!");
							damage = -100;
						} 
						else if (randomNumber > 0.4 && randomNumber < 0.6) {
							Debug.Log("Wave Striker Hit 3 times!");
							damage = -75;
						} 
						else if (randomNumber > 0.2 && randomNumber < 0.4) {
							Debug.Log("Wave Striker Hit 2 times!");
							damage = -50;
						} 
						else if (randomNumber > 0.05 && randomNumber < 0.2) {
							Debug.Log("Wave Striker Hit 1 time!");
							damage = -25;
						} 
						else {
							Debug.Log("The Attack Missed!");
							damage = 0;
						}

					}
					if(ElementTier == 3){
						//Tsunami Serenade: If the tension meter (Fan Bar) is over 300, it instantly
						//Deals Massive Damage that ends the performance. (Insta Win :DDD )
						//However, if you end up using it early, it will only deal 1 damage.
						if(targetStats.returnHealth() > 300){
							Debug.Log("Tsunami Serenade is Used");
							damage = -100;
						}
						else{
							Debug.Log("Tsunami Serenade Failed");
							damage = -1;
						}


					}
				}
					//List of Earth Magic Attacks.
				else if(ElementChecker == 5){
						Debug.Log("The Player Used Earth Magic");
						if(ElementTier == 1){
							//Rock Breaker:Deals slightly more damage than a normal attack.
							//Has a low chance of stunning each opponents.
							Debug.Log("The Player Used Rock Breaker");
							damage = damage * 1.25f;

							GameObject[] possibleEnemies = GameObject.FindGameObjectsWithTag ("EnemyUnit");
							Debug.Log("Length of enemies" + possibleEnemies.Length);
							foreach (GameObject enemyUnit in possibleEnemies) {
								UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats> ();
								float randomNumber = Random.value;
								Debug.Log("The Enemy is currently " + currentUnitStats.name);
								if (randomNumber < 0.2) {
									Debug.Log("The Enemy is Stunned!");
									currentUnitStats.stun = true;
									damage = 0;
								} 
								else {
									Debug.Log("The Enemy is not Frozen!");
									damage = 0;
								}

							}
							
						}
						if(ElementTier == 2){
							//Earth Grasp: Attacks the enemies with a chance of lowering the Enemy attack.
							GameObject[] possibleEnemies = GameObject.FindGameObjectsWithTag ("EnemyUnit");
							Debug.Log("Length of enemies" + possibleEnemies.Length);
							foreach (GameObject enemyUnit in possibleEnemies) {
								UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats> ();
								float randomNumber = Random.value;
								Debug.Log("The Enemy is currently " + currentUnitStats.name);
								if (randomNumber < 0.25) {
									Debug.Log("The Enemy is Debuffed!");
									damage = damage * 2;
									 
									GameObject[] EnemyList = GameObject.FindGameObjectsWithTag ("EnemyUnit");
									Debug.Log("Length of enemies" + EnemyList.Length); 
									foreach(GameObject Ex in EnemyList){
										UnitStats currEnemey = Ex.GetComponent<UnitStats> ();
										currEnemey.attack = currEnemey.attack-5;
									}
								} 
								else {
									Debug.Log("The Enemy is not Slowed");
									damage = damage * 2;
								}

							}

						}
						if(ElementTier == 3){
							Debug.Log("The Player Used Ganseki Shatter");
							//Ganseki Shatter.
							//For the rest of the match, the enemies will have 1/2 attack.
							//The user's spell will cause them to have low speed and attack last.
							damage = 0;
							GameObject[] possibleEnemies = GameObject.FindGameObjectsWithTag ("EnemyUnit");
							Debug.Log("Length of enemies" + possibleEnemies.Length);

							foreach (GameObject enemyUnit in possibleEnemies) {
								UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats> ();
								currentUnitStats.attack = currentUnitStats.attack/2;
							}
							ownerStats.speed = 1;
						}
					}

					//List of Lightning Magic Attacks.
				if(ElementChecker == 6){
						Debug.Log("The Player Used Lightning Magic");
						if(ElementTier == 1){
							//Lightning Flash: Attacks the Foe 1 - 2 times.
							//If Thunder Dance is active Attacks the Foe 3 - 5 times.
							Debug.Log("The Player Used Lightning Flash");
							float randomNumber = Random.value;
							if(ownerStats.ThunderDance == true){
								if (randomNumber > 0.66) {
									damage = damage * 5;
								}
								else if (randomNumber > 0.33 && randomNumber < 0.66) {
									damage = damage * 4;
								}
								else if (randomNumber < 0.33) {
									damage = damage * 3;
								}
							}
							else{
								if (randomNumber > 0.5) {
									damage = damage * 2;
								}
								else{
									damage = damage * 1;
								}
							}
						}
						if(ElementTier == 2){
							//Thunder Dance: Makes the player tap into the Thunder.
							//Attack Normally and Grants additional speed on use as a bonus.
							if(ownerStats.ThunderDance == false){
								Debug.Log("The Player Used Thunder Dance");
								ownerStats.ThunderDance = true;
								ownerStats.speed = ownerStats.speed + 10;
							}
							else{
								Debug.Log("The Player already is in the zone!");
								ownerStats.speed = ownerStats.speed + 10;
							}
							
							
						}
						if(ElementTier == 3){
							Debug.Log("Kaminari Equalizer");
							//Kaminari Equalizer. If the Tension Bar (The Fan Bar) is lower than half,
							//Reset its entire position back to neutral. Else, deal 50 base damage.
							damage = 0;
							if(targetStats.returnHealth() < 200){
								targetStats.health = 200;
							}
							else{
								damage = -50;
							}
						}
				}
			}
			else{
				Debug.Log("Enemy Strikes Back!");
			}
			//Call Animator and play attack animation.
			this.owner.GetComponent<Animator> ().Play (this.attackAnimation);
			//Enemy Receives Damage
			targetStats.receiveDamage (damage);
			
			//Subtract MP from Player
			ownerStats.mana -= this.manaCost;
		}
		else{
			Debug.Log("Not enough Mana!");
			float d = 0;
			this.owner.GetComponent<Animator> ().Play (this.attackAnimation);
			//Enemy Receives Damage
			targetStats.receiveDamage (d);
		}
	}
}


