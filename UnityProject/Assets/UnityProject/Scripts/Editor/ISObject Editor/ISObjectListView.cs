using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor
    {
        Vector2 _scrollPos = Vector2.zero;
        int _listViewWidth = 200;
        int _listViewButtonWidth = 190;
        int _listViewButtonHeight = 30;

        void ListView()
        {
            _scrollPos = GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));
            GUILayout.Label("List View");
            GUILayout.EndScrollView();
        }
    }
}