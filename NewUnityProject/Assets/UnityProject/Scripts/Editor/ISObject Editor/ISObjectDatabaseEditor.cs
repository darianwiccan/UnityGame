using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor : EditorWindow
    {
        ISObjectDatabaseType<ISWeaponDatabase, ISWeapon> weaponDB = new ISObjectDatabaseType<ISWeaponDatabase, ISWeapon>("ISWeaponDB.asset");
        ISObjectDatabaseType<ISArmorDatabase, ISArmor> armorDB = new ISObjectDatabaseType<ISArmorDatabase, ISArmor>("ISArmorDB.asset");
//      ISObjectDatabaseType<ISQualityDatabase, ISQuality> qualityDB = new ISObjectDatabaseType<ISQualityDatabase, ISQuality>("ISQualityDB.asset");
        ISObjectDatabaseType<ISPotionDatabase, ISPotion> potionDB = new ISObjectDatabaseType<ISPotionDatabase, ISPotion>("ISPotionDB.asset");
        ISObjectDatabaseType<ISSpellDatabase, ISSpell> spellDB = new ISObjectDatabaseType<ISSpellDatabase, ISSpell>("ISSpellDB.asset");
        ISQualityDatabase qualityDB = new ISQualityDatabase();

        Vector2 buttonSize = new Vector2(190, 25);
        int _listViewWidth = 200;

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
            weaponDB.OnEnable("Weapon");
            armorDB.OnEnable("Armor");
            potionDB.OnEnable("Potion");
            spellDB.OnEnable("Spell");
            qualityDB = ScriptableObjectDatabase<ISQuality>.GetDatabase<ISQualityDatabase>(@"Database", "ISQualityDB.asset");
            if (qualityDB.Count < 1)
                qualityDB.Add(null);
            tabState = TabState.WEAPON;
        }

        void OnGUI()
        {
            TopTabBar();

            GUILayout.BeginHorizontal();

            switch (tabState)
            {
                case TabState.WEAPON:
                    weaponDB.OnGUI(buttonSize, _listViewWidth);
                    break;
                case TabState.ARMOR:
                    armorDB.OnGUI(buttonSize, _listViewWidth);
                    break;
                case TabState.POTION:
                    potionDB.OnGUI(buttonSize, _listViewWidth);
                    break;
                case TabState.SPELL:
                    spellDB.OnGUI(buttonSize, _listViewWidth);
                    break;
                default:
                    break;
            }

            GUILayout.EndHorizontal();
            BottomBar();
        }
    }
}