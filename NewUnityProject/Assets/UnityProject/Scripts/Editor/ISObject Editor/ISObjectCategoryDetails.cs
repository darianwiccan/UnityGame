using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject, new()
    {
        public void ItemDetails()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.Space(5);
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            if (showDetails)
                DisplayNewArmor();

            GUILayout.EndVertical();

            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            DisplayButtons();
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
        }

        void DisplayNewArmor()
        {
            tempItem.OnGUI();
        }

        void DisplayButtons()
        {
            if (showDetails)
            {
                SaveButton();
                DeleteButton();
                CancelButton();
            }
            else
            {
                CreateItemButton();
            }
        }

        void CreateItemButton()
        {
            if (GUILayout.Button("Create " + strItemType))
            {
                tempItem = new T();
                showDetails = true;
            }
        }

        void SaveButton()
        {
            GUI.SetNextControlName("SaveButton");
            if (GUILayout.Button("Save"))
            {
                if (_selectedIndex == -1)
                {
                    Add(tempItem);
                }
                else
                {
                    Replace(_selectedIndex, tempItem);
                }
                tempItem = null;
                _selectedIndex = -1;
                showDetails = false;
                GUI.FocusControl("SaveButton");
            }
        }

        void DeleteButton()
        {
            if (_selectedIndex != -1)
            {
                if (GUILayout.Button("Delete"))
                {
                    if (EditorUtility.DisplayDialog("Delete Armor",
                                                    "Are you sure you want to delete " + tempItem.ISOName + " from the database?",
                                                    "Delete",
                                                    "Cancel"))
                    {
                        Remove(_selectedIndex);
                        tempItem = null;
                        _selectedIndex = -1;
                        showDetails = false;
                        GUI.FocusControl("SaveButton");
                    }
                }
            }
        }

        void CancelButton()
        {
            if (GUILayout.Button("Cancel"))
            {
                tempItem = null;
                _selectedIndex = -1;
                showDetails = false;
                GUI.FocusControl("SaveButton");
            }
        }
    }
}