using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    public interface IISEquipable
    {
        ISEquipmentSlot EquipmentSlot { get; }
        bool Equip();
    }
}