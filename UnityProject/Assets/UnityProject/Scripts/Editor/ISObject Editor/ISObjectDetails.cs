using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor
    {
        void ObjectDetails()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.Label("Detail View");
            GUILayout.EndHorizontal();
        }
    }
}