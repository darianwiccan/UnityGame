using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor
    {
        void BottomBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            GUILayout.Label("Bottom Bar");
            GUILayout.EndHorizontal();
        }
    }
}