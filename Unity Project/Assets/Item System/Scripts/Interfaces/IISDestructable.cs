using UnityEngine;
using System.Collections;

namespace UnityGame.ItemSystem
{
    public interface IISDestructable
    {
        int Durability { get; }
        int MaxDurability { get; }
        void TakeDamate(int amount);
        void Repair();
        void Break();
    }
}