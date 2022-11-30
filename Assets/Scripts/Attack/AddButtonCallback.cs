using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//AddButtonCallBack is a script used for making a button have  
public class AddButtonCallback : MonoBehaviour {

	//Gets the integer depending on the Attack. 
	//1 = 
	[SerializeField]
	private int AttackType;

	//When the Button is clicked on, initiate player attack.
	void Start () {
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => addCallback());
	}

	private void addCallback() {
		GameObject playerParty = GameObject.Find ("PlayerParty");
		playerParty.GetComponent<SelectUnit> ().selectAttack (this.AttackType);
	}

}
