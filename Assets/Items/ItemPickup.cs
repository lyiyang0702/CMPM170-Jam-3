using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        //Debug.Log(PlayerManager.instance.CurrentPlayer.name + "Picking up " + item.name);
        //bool wasPickedUp = PlayerManager.instance.CurrentPlayer.GetComponent<Inventory>().Add(item);
        //if (wasPickedUp)
        //{
        //    Destroy(gameObject);
        //}

        bool wasPickedUp = PlayerManager.instance.currentPlayerUnit.GetComponent<Inventory>().Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }

    }
}
