using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor
    {
        ISWeapon tempWeapon = new ISWeapon();
        bool showNewWeaponDetails = false;

        void ObjectDetails()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.Space(5);
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            if (showNewWeaponDetails)
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
            if (!showNewWeaponDetails)
            {
                if (GUILayout.Button("Create Weapon"))
                {
                    tempWeapon = new ISWeapon();
                    showNewWeaponDetails = true;
                }
            }
            else
            {
                if (GUILayout.Button("Save"))
                {
                    showNewWeaponDetails = false;
                    tempWeapon = null;
                }
                
                if (GUILayout.Button("Cancel"))
                {
                    showNewWeaponDetails = false;
                    tempWeapon = null;
                }
            }
        }
    }
}