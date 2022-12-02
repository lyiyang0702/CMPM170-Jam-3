using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;
 
    public List<Item> items = new List<Item>();

    private SFXManager sfxMan;

    void Start()
    {
        sfxMan = FindObjectOfType<SFXManager>();
    }

    public bool Add(Item item)
    {

        if (!item.isDefaultItem)
        {
            // Check if out of space
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            items.Add(item);
            sfxMan.menuBack.Play();
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
            item.Use(this.gameObject);
        }

        
        return true;
    }

  
    public void Remove(Item item)
    {
        items.Remove(item);     


        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
