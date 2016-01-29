using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor : EditorWindow
    {
        ISWeaponDatabase weaponDatabase;

        const string DB_NAME = @"ISWeaponDB.asset";
        const string DB_PATH = @"Database";
        const string DB_FULL_PATH = @"Assets/" + DB_PATH + "/" + DB_NAME;

        [MenuItem("UnityProject/Database/Object Editor %#i")]
        public static void Init()
        {
            ISObjectDatabaseEditor window = EditorWindow.GetWindow<ISObjectDatabaseEditor>();
            window.minSize = new Vector2(800, 600);
            window.titleContent.text = "Object DB";
            window.Show();
        }

        void OnEnable()
        {
            if (weaponDatabase == null)
                weaponDatabase = ISWeaponDatabase.GetDatabase<ISWeaponDatabase>(DB_PATH, DB_NAME);

            tabState = TabState.WEAPON;
        }

        void OnGUI()
        {
            TopTabBar();

            GUILayout.BeginHorizontal();

            switch (tabState)
            {
                case TabState.WEAPON:
                    ListView();
                    ObjectDetails();
                    break;
                case TabState.ARMOR:
                    break;
                case TabState.POTION:
                    break;
                case TabState.SPELL:
                    break;
                default:
                    break;
            }


            GUILayout.EndHorizontal();
            BottomBar();
        }
    }
}