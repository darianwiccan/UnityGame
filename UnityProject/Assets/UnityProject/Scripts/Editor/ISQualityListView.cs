using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor
    {
        void ListView()
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));
            DisplayQualities();
            EditorGUILayout.EndScrollView();
        }

        void DisplayQualities()
        {
            for (int i = 0; i < qualityDatabase.Count; i++)
            {
                //Sprite
                if (qualityDatabase.Get(i).Icon)
                    selectedTexture = qualityDatabase.Get(i).Icon.texture;
                else
                    selectedTexture = null;

                if (GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
                {
                    int controllerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                    EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controllerID);
                    selectedIndex = i;
                }

                string commandName = Event.current.commandName;

                if (commandName == "ObjectSelectorUpdated")
                {
                    if (selectedIndex != -1)
                    {
                        qualityDatabase.Get(selectedIndex).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                    }
                    Repaint();
//                  selectedIndex = -1;
                }

                //Name
                GUILayout.Label(qualityDatabase.Get(i).Name);
                //Delete Button
                GUILayout.Button("X");
            }
        }
    }
}