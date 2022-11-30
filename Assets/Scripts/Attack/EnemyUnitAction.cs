using UnityEngine;
using System.Collections;

//EnemyUnitAction is the primary action the enemy.
//Need to change because this specific script targets random player units.
//Also need to modify if we are gonna have multiple enemy attacks.
//FIX ME
public class EnemyUnitAction : MonoBehaviour {
	//Initializes what the enemy attack is.
	[SerializeField]
	private GameObject attack;

	[SerializeField]
	private string targetsTag;

	void Awake () {
		this.attack = Instantiate (this.attack);

		this.attack.GetComponent<AttackTarget> ().owner = this.gameObject;
	}

	GameObject findRandomTarget() {
		GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag (targetsTag);

		if (possibleTargets.Length > 0) {
			int targetIndex = Random.Range (0, possibleTargets.Length);
			GameObject target = possibleTargets [targetIndex];

			return target;
		}

		return null;
	}

	public void act() {
		GameObject target = findRandomTarget ();
		this.attack.GetComponent<AttackTarget> ().hit (target, true);
	}
}
