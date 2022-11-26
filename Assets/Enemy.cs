using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStat myStat;
    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStat = GetComponent<CharacterStat>();
    }
    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.CurrentPlayer.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //playerCombat.Attack(myStat);
            }
            
        }
    }
}
