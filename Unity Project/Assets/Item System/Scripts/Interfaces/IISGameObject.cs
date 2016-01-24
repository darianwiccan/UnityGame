using UnityEngine;
using System.Collections;

namespace UnityGame.ItemSystem
{
    public interface IISGameObject
    {
        GameObject Prefab { get; set; }
    }
}