using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    public interface IISWeapon
    {
        int MinDamage { get; set; }
        int Attack();
    }
}