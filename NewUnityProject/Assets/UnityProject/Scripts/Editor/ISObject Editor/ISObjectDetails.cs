using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor
    {
        ISWeapon tempWeapon = new ISWeapon();

        void ObjectDetails()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.Space(5);
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            if (showDetails)
                DisplayNewWeapon();

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
            if (!showDetails)
            {
                if (GUILayout.Button("Create Weapon"))
                {
                    tempWeapon = new ISWeapon();
                    showDetails = true;
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
                    tempWeapon = null;
                    _selectedIndex = -1;
                    showDetails = false;
                    GUI.FocusControl("SaveButton");
                }

                if (_selectedIndex != -1)
                {
                    if (GUILayout.Button("Delete"))
                    {
                        if (EditorUtility.DisplayDialog("Delete Weapon",
                                                        "Are you sure you want to delete " + tempWeapon.ISOName + " from the database?",
                                                        "Delete",
                                                        "Cancel"))
                        {
                            weaponDatabase.Remove(_selectedIndex);
                            tempWeapon = null;
                            _selectedIndex = -1;
                            showDetails = false;
                            GUI.FocusControl("SaveButton");
                        }
                    }
                }

                if (GUILayout.Button("Cancel"))
                {
                    tempWeapon = null;
                    _selectedIndex = -1;
                    showDetails = false;
                    GUI.FocusControl("SaveButton");
                }
            }
        }
    }
}