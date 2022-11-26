using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    [SerializeField]
    public virtual void Use(GameObject character)
    {
        // use item in some way
        //Debug.Log("Using " + name);
    }

    public void RemoveFromInventory(GameObject character)
    {
        character.GetComponent<Inventory>().Remove(this);
    }
}
