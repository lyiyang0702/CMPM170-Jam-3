using UnityEngine;
using System.Collections;

//Destorys Enemy Game Object.
//Used when deleting Enemy from scene after they lose all health or end the game. 

//Attatched to: Enemy Characters.
public class KillEnemy : MonoBehaviour {

	public GameObject menuItem;

	void OnDestroy() {
		Destroy (this.menuItem);
	}
}
