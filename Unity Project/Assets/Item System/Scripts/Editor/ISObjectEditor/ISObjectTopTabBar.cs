using UnityEngine;
using System.Collections;

namespace UnityGame.ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        void TopTabBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            WeaponTab();
            ArmorTab();
            GUILayout.Button("Potions");
            GUILayout.Button("Spells");
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

        void AboutTab()
        {
            GUILayout.Button("About");
        }
    }
}