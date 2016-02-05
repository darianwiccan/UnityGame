using UnityEngine;
using System.Collections;
using UnityProject.ItemSystem;

[DisallowMultipleComponent]
public class Demo1 : MonoBehaviour
{
    public ISWeaponDatabase database;

    void OnGUI()
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (GUILayout.Button("Spawn " + database.Get(i).ISOName))
            {
                Spawn(i);
            }
        }
    }

    void Spawn(int index)
    {
        ISWeapon isw = database.Get(index);
        GameObject weapon = Instantiate(isw.Prefab);
        weapon.name = isw.ISOName;
        Weapon myWeapon = weapon.AddComponent<Weapon>();

        myWeapon.Icon = isw.ISOIcon;
        myWeapon.Value = isw.ISOValue;
        myWeapon.Burden = isw.ISOBurden;
        myWeapon.Quality = isw.ISOQuality.Icon;
        myWeapon.Min_Damage = isw.MinDamage;
        myWeapon.Durability = isw.Durability;
        myWeapon.Max_Durability = isw.MaxDurability;
        myWeapon.Equipment_Slot = isw.equipmentSlot;

    }
}
