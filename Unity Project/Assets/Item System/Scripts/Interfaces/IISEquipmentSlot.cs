using UnityEngine;
using System.Collections;

namespace UnityGame.ItemSystem
{
    public interface IISEquipmentSlot
    {
        string Name { get; set; }
        Sprite Icon { get; set; }
    }
}