using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    private CharacterStat myStat;
    private void Start()
    {
       myStat = GetComponent<CharacterStat>();
    }
    public void Attack (CharacterStat targetStat)
    {

        targetStat.TakeDamage(myStat.damage.GetValue());
    }
}
