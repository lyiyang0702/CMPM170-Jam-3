using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CharacterStat
{
    EquipmentManager equipmentManager;
    // Start is called before the first frame update
    void Start()
    {
        equipmentManager = GetComponent<EquipmentManager>();
        equipmentManager.onEquipmentChanged += OnEquipmentChanged;
    }


    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {

            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }
        if (oldItem != null)
        {

            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(newItem.damageModifier);
        }
    }


}
