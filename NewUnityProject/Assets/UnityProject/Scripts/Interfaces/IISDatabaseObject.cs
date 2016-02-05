using UnityEngine;
using System.Collections;

public interface IISDatabaseObject
{
    string Name { get; set; }
    Sprite Icon { get; set; }
    void Clone<T>(IISDatabaseObject item);
    void OnGUI();
}
