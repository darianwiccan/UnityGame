using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq; // needed for ElementAt

namespace UnityProject.ItemSystem
{
    public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality>
    {
        public int GetIndex(string name)
        {
            return items.FindIndex(a => a.Name == name);
        }
    }
}