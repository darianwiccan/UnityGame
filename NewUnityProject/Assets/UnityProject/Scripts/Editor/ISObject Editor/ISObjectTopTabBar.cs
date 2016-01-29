using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor
    {
        enum TabState
        {
            WEAPON,
            ARMOR,
            POTION,
            SPELL,
            ABOUT
        }

        TabState tabState;

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
            if (GUILayout.Button("Weapons"))
                tabState = TabState.WEAPON;
        }

        void ArmorTab()
        {
            if (GUILayout.Button("Armor"))
                tabState = TabState.ARMOR;
        }

        void PotionTab()
        {
            if (GUILayout.Button("Potions"))
                tabState = TabState.POTION;
        }

        void SpellTab()
        {
            if (GUILayout.Button("Spells"))
                tabState = TabState.SPELL;
        }

        void AboutTab()
        {
            if (GUILayout.Button("About"))
                tabState = TabState.ABOUT;
        }
    }
}