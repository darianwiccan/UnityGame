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
        int _listViewButtonHeight = 25;

        int _selectedIndex = -1;

        Vector2 buttonSize = new Vector2(190, 25);

        void ListView()
        {
            _scrollPos = GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

            for (int i = 0; i < weaponDatabase.Count; i++)
            {
                if (GUILayout.Button(weaponDatabase.Get(i).ISOName, "box", GUILayout.Width(_listViewButtonWidth), GUILayout.Height(_listViewButtonHeight)))
                {
                    if (showDetails)
                        return;
                    _selectedIndex = i;
                    tempWeapon = new ISWeapon();
                    tempWeapon.Clone(weaponDatabase.Get(i));
                    showDetails = true;
                    GUI.FocusControl("SaveButton");
                }
            }

            GUILayout.EndScrollView();
        }
    }
}