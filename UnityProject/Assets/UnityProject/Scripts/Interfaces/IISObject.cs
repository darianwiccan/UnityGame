using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    public interface IISObject
    {
        string ISName { get; set; }
        Sprite ISIcon { get; set; }
        int ISValue { get; set; }
        int ISBurden { get; set; }
        ISQuality ISQuality { get; set; }
    }
}