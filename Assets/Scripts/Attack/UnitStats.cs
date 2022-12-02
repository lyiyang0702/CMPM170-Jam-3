using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using static EquipmentManager;

//UnitStats Script Gives Players and Monsters various stats
public class UnitStats : MonoBehaviour, IComparable {

	[SerializeField]
	private Animator animator;

	//DamageText UI placement. 
	//Maybe can get Rid of???? IDK :P
	[SerializeField]
	private GameObject damageTextPrefab;
	[SerializeField]
	private Vector2 damageTextPosition;

	//Stats of each unit.
	//Probably don't need health.
	public float health;
	public float mana;
	public float attack;
	public float magic;
	public float defense;
	public float speed;

	public int element;

	//
	public int nextActTurn;

	private bool dead = false;

	public bool stun = false;


	public bool isNotPlayer;
	private float currentExperience;

	public int FlameFistBuff;
	public bool EmberSong;

	public bool ThunderDance;

	public int HurricaneVortex;

    EquipmentManager equipmentManager;
    void Start() {
        if (this.gameObject.CompareTag("PlayerUnit"))
        {
            equipmentManager = GetComponent<EquipmentManager>();
            equipmentManager.onEquipmentChanged += OnEquipmentChanged;
        }
    }
	//When the player gets hit the health of the player decreases.
	//FIXME: Need to change subtracting health and change it to progress bar.
	public void receiveDamage(float damage) {
		this.health -= damage;
		animator.Play ("Hit");
		//Display amount of damage taken.
		GameObject HUDCanvas = GameObject.Find ("HUDCanvas");
		GameObject damageText = Instantiate (this.damageTextPrefab, HUDCanvas.transform) as GameObject;
		damageText.GetComponent<Text> ().text = "" + damage;
		damageText.transform.localPosition = this.damageTextPosition;
		damageText.transform.localScale = new Vector2 (1.0f, 1.0f);
		//If the Health is less then 0 the player character is dead.
		if (this.health <= 0) {
			this.dead = true;
			this.gameObject.tag = "DeadUnit";
			Destroy (this.gameObject);
		}
	}

	//Calculate when the player can act 
	public void calculateNextActTurn(int currentTurn) {
		this.nextActTurn = currentTurn + (int)Math.Ceiling(100.0f / this.speed);
	}

	//Compares Speed stat
	public int CompareTo(object otherStats) {
		return nextActTurn.CompareTo (((UnitStats)otherStats).nextActTurn);
	}

	//Checks to see if player unit is alive.
	public bool isDead() {
		return this.dead;
	}

	public float returnHealth() {
		return this.health;
	}
	//Declaration for when the player recieves EXP from battles.
	public void receiveExperience(float experience) {
		this.currentExperience += experience;
	}

	public bool isStuned(){
		return this.stun;
	}

	public bool resetStun(){
		return !this.stun;
	}

	public bool isNotPlayable(){
		return this.isNotPlayer;
	}

	public int returnFlameFist() {
		return this.FlameFistBuff;
	}
	public bool emberEffect(){
		return this.EmberSong;
	}

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            this.attack += newItem.damageModifier;
            this.defense += newItem.armorModifier;
			GetComponent<PlayerUnitAction>().elementAttack = newItem.ElementAttacks[0];
			GetComponent<PlayerUnitAction>().elementAttack2 = newItem.ElementAttacks[1];
			GetComponent<PlayerUnitAction>().elementAttack3 = newItem.ElementAttacks[2];
        }
        if (oldItem != null)
        {
            this.attack -= newItem.damageModifier;
            this.defense -= newItem.armorModifier;
        }
    }
}
