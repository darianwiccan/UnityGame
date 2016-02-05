using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    public interface IISSpell
    {
        int SpellLevel { get; set; }
        int ManaCost { get; set; }
        int Cooldown { get; set; }
        int SpellRange { get; set; }
    }
}