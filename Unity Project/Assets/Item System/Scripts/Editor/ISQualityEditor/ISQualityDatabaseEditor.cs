using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityGame.ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor : EditorWindow
    {
        ISQualityDatabase qualityDatabase;

        Texture2D selectedTexture;
        int selectedIndex = -1;
        Vector2 _scrollPos;

        const int SPRITE_BUTTON_SIZE = 42;

        const string DATABASE_NAME = @"QualityDatabase.asset";
        const string DATABASE_PATH = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_PATH + "/" + DATABASE_NAME;

        [MenuItem("UnityGame/Database/Quality Editor %#w")]

        public static void Init()
        {
            ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
            window.minSize = new Vector2(400, 300);
            window.titleContent = new GUIContent("Quality DB");
            window.Show();
        }

        void OnEnable()
        {
            qualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
            qualityDatabase = qualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);
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
            GUILayout.Label("Qualities: " + qualityDatabase.Count);

            if (GUILayout.Button("Add"))
            {
                qualityDatabase.Add(new ISQuality());
            }
        }
    }
}