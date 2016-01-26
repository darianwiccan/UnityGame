using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor : EditorWindow 
    {
        ISQualityDatabase qualityDatabase;
        Texture2D selectedTexture;
        int selectedIndex = -1;
        Vector2 _scrollPos; // used in ISQualityListView.cs

        const int SPRITE_BUTTON_SIZE = 42;
        const string DB_NAME = @"ISQualityDB.asset";
        const string DB_PATH = @"Database";
        const string DB_FULL_PATH = @"Assets/" + DB_PATH + "/" + DB_NAME;


        [MenuItem("UnityProject/Database/Quality Editor %#w")]
        public static void Init()
        {
            ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
            window.minSize = new Vector2(400, 300);
            window.titleContent.text = "Quality DB";
            window.Show();
        }

        void OnEnable()
        {
            if (qualityDatabase == null)
                qualityDatabase = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DB_PATH, DB_NAME);
        }

        void OnGUI()
        {
            if (qualityDatabase == null)
            {
                Debug.LogWarning("qualityDatabase not loaded");
                return;
            }
            ListView();
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            BottomBar();
            GUILayout.EndHorizontal();
        }

        void BottomBar()
        {
            //Count
            GUILayout.Label("Qualities in Database: " + qualityDatabase.Count);
            //Add Button
            if (GUILayout.Button("Add new Quality"))
            {
                qualityDatabase.Add(new ISQuality());
            }
        }
    }
}
