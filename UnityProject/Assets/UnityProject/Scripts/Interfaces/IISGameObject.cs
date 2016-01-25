using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    public interface IISGameObject
    {
        GameObject Prefab { get; set; }
    }
}