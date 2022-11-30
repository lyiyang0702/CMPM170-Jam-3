using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//AddButtonCallBack is a script used for making a button have  
public class AddButtonCallback : MonoBehaviour {

	//Gets the boolean from the user's input whether or not the skill is a magic based one or a physical based one.
	[SerializeField]
	private bool physical;

	//When the Button is clicked on, initiate player attack.
	void Start () {
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => addCallback());
	}

	private void addCallback() {
		GameObject playerParty = GameObject.Find ("PlayerParty");
		playerParty.GetComponent<SelectUnit> ().selectAttack (this.physical);
	}

}
