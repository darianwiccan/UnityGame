using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor
    {
        enum DisplayState
        {
            NONE,
            DETAILS
        };

        ISWeapon tempWeapon = new ISWeapon();
        bool showNewWeaponDetails = false;

        DisplayState state = DisplayState.NONE;

        void ObjectDetails()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.Space(5);
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            switch (state)
            {
                case DisplayState.DETAILS:
                    if (showNewWeaponDetails)
                        DisplayNewWeapon();
                    break;
                default:
                    break;
            }

            GUILayout.EndVertical();

            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            DisplayButtons();
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
        }

        void DisplayNewWeapon()
        {

            tempWeapon.OnGUI();
        }

        void DisplayButtons()
        {
            if (!showNewWeaponDetails)
            {
                if (GUILayout.Button("Create Weapon"))
                {
                    tempWeapon = new ISWeapon();
                    showNewWeaponDetails = true;
                    state = DisplayState.DETAILS;
                }
            }
            else
            {
                GUI.SetNextControlName("SaveButton");
                if (GUILayout.Button("Save"))
                {
                    if (_selectedIndex == -1)
                    {
                        weaponDatabase.Add(tempWeapon);
                    }
                    else
                    {
                        weaponDatabase.Replace(_selectedIndex, tempWeapon);
                    }
                    showNewWeaponDetails = false;
                    tempWeapon = null;
                    _selectedIndex = -1;
                    state = DisplayState.NONE;
                    GUI.FocusControl("SaveButton");
                }

                if (_selectedIndex != -1)
                {
                    if (GUILayout.Button("Delete"))
                    {
                        if (EditorUtility.DisplayDialog("Delete Weapon",
                                                        "Are you sure you want to delete " + weaponDatabase.Get(_selectedIndex).ISOName + " from the database?",
                                                        "Delete",
                                                        "Cancel"))
                        {
                            weaponDatabase.Remove(_selectedIndex);
                            showNewWeaponDetails = false;
                            tempWeapon = null;
                            _selectedIndex = -1;
                            state = DisplayState.NONE;
                            GUI.FocusControl("SaveButton");
                        }
                    }
                }

                if (GUILayout.Button("Cancel"))
                {
                    showNewWeaponDetails = false;
                    tempWeapon = null;
                    _selectedIndex = -1;
                    state = DisplayState.NONE;
                    GUI.FocusControl("SaveButton");
                }
            }
        }
    }
}