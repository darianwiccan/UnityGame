using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    public interface IISObject
    {
        string ISOName { get; set; }
        Sprite ISOIcon { get; set; }
        int ISOValue { get; set; }
        int ISOBurden { get; set; }
        ISQuality ISOQuality { get; set; }
    }
}