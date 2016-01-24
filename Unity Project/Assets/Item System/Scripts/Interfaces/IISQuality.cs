using UnityEngine;
using System.Collections;

namespace UnityGame.ItemSystem
{
    public interface IISQuality
    {
        string Name { get; set; }
        Sprite Icon { get; set; }
    }
}