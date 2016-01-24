using UnityEngine;
using System.Collections;

namespace UnityGame.ItemSystem
{
    public interface IISEquipable
    {
        ISEquipmentSlot EquipmentSlot { get; }
        bool Equip();
    }
}