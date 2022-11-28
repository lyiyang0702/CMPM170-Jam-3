using UnityEngine;
using System.Collections;


//Shows the MP for the Player Unit.
public class ShowUnitMana : ShowUnitStat {

	//Overrides the previous value of MP
	//And Updates it. 
	override protected float newStatValue() {
		return unit.GetComponent<UnitStats> ().mana;
	}
}
