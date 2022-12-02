using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    bool wasPickedUp;
    GameObject[] playerUnits;

    private void Start()
    {
        playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
    }
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        AddItem();
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }

    }

    void AddItem()
    {
        if (item.name == "Guitar")
        {
            wasPickedUp = GetInventory("WarriorUnit").GetComponent<Inventory>().Add(item);
        }
        else if (item.name == "Violin")
        {
            wasPickedUp = GetInventory("MageUnit").GetComponent<Inventory>().Add(item);
        }
        // add third player here
    }
    GameObject GetInventory(string playerUnitName)
    {
        foreach (GameObject playerUnit in playerUnits)
        {
            if (playerUnit.name == playerUnitName)
            {
                return playerUnit;
            }
        }
        return null;
    }
}