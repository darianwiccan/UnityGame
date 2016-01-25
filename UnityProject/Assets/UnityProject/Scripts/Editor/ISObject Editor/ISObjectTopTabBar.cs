using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor
    {
        void TopTabBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            WeaponTab();
            ArmorTab();
            PotionTab();
            SpellTab();
            AboutTab();
            GUILayout.EndHorizontal();
        }

        void WeaponTab()
        {
            GUILayout.Button("Weapons");
        }

        void ArmorTab()
        {
            GUILayout.Button("Armor");
        }

        void PotionTab()
        {
            GUILayout.Button("Potions");
        }

        void SpellTab()
        {
            GUILayout.Button("Spells");
        }

        void AboutTab()
        {
            GUILayout.Button("About");
        }
    }
}