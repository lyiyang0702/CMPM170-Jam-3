using UnityEngine;
using System.Collections;

public class KillDamageText : MonoBehaviour {

	[SerializeField]
	private float destroyTime;

	
	void Start () {
		Destroy (this.gameObject, this.destroyTime);
	}
	
	void OnDestroy() {
		GameObject turnSystem = GameObject.Find ("TurnSystem");
		turnSystem.GetComponent<TurnSystem> ().nextTurn ();
	}
}
