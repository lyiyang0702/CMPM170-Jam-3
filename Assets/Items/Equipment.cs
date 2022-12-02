using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public int damageModifier;
    public int armorModifier;
    public GameObject[] ElementAttacks;
    public override void Use(GameObject character)
    {
        base.Use(character);
        Debug.Log("Equipping " + name);
        // equip 
        character.GetComponent<EquipmentManager>().Equip(this);
        // remove from inventory after equipped
        RemoveFromInventory(character);

    }

    public enum EquipmentSlot { Weapon, Medicine, Accessory}
}
