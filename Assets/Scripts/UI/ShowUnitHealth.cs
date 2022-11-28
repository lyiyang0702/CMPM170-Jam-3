using UnityEngine;
using System.Collections;

//Shows the Health for the Player Unit.
//Need to tweak/get rid of due to current health system.
public class ShowUnitHealth : ShowUnitStat {
	//Overrides the stat to show current health.
	override protected float newStatValue() {
		return unit.GetComponent<UnitStats> ().health;
	}
}
