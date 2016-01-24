using UnityEngine;
using System.Collections;

namespace UnityGame.ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        void BottomStatusBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

            GUILayout.Label("Status Bar");

            GUILayout.EndHorizontal();
        }
    }
}