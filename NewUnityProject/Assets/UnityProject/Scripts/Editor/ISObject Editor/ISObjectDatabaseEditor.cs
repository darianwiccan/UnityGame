using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor : EditorWindow
    {
        ISWeaponDatabase weaponDatabase;
//      ISObjectCategory armorDatabase = new ISObjectCategory();

        ISObjectDatabaseType<ISWeaponDatabase, ISWeapon> weaponDB = new ISObjectDatabaseType<ISWeaponDatabase, ISWeapon>("ISWeaponDB.asset");
        ISObjectDatabaseType<ISArmorDatabase, ISArmor> armorDB = new ISObjectDatabaseType<ISArmorDatabase, ISArmor>("ISArmorDB.asset");

        const string DB_NAME = @"ISWeaponDB.asset";
        const string DB_PATH = @"Database";
        const string DB_FULL_PATH = @"Assets/" + DB_PATH + "/" + DB_NAME;

        public bool showDetails = false;

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
//          if (weaponDatabase == null)
//              weaponDatabase = ISWeaponDatabase.GetDatabase<ISWeaponDatabase>(DB_PATH, DB_NAME);

//          armorDatabase.OnEnable();

            weaponDB.OnEnable("Weapon");
            armorDB.OnEnable("Armor");

            tabState = TabState.ABOUT;
        }

        void OnGUI()
        {
            TopTabBar();

            GUILayout.BeginHorizontal();

            switch (tabState)
            {
                case TabState.WEAPON:
                    weaponDB.OnGUI(buttonSize, _listViewWidth);
//                  ListView();
//                  ObjectDetails();
                    break;
                case TabState.ARMOR:
                    armorDB.OnGUI(buttonSize, _listViewWidth);
//                  armorDatabase.OnGUI(buttonSize, _listViewWidth);
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