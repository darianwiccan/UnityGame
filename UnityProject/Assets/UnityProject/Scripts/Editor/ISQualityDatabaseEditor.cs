using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor : EditorWindow 
    {
        ISQualityDatabase qualityDatabase;
        ISQuality selectedItem;
        Texture2D selectedTexture;
        int selectedIndex = -1;
        Vector2 _scrollPos; // used in ISQualityListView.cs

        const int SPRITE_BUTTON_SIZE = 42;
        const string DB_FILE_NAME = @"ISQualityDB.asset";
        const string DB_FOLDER_NAME = @"Database";
        const string DB_FULL_PATH = @"Assets/" + DB_FOLDER_NAME + "/" + DB_FILE_NAME;


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
            qualityDatabase = AssetDatabase.LoadAssetAtPath(DB_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;

            if (qualityDatabase == null)
            {
                if (!AssetDatabase.IsValidFolder(@"Assets/" + DB_FOLDER_NAME))
                {
                    AssetDatabase.CreateFolder(@"Assets", DB_FOLDER_NAME);
                    qualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
                    AssetDatabase.CreateAsset(qualityDatabase, DB_FULL_PATH);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
            }
            selectedItem = new ISQuality();
        }

        void OnGUI()
        {
            ListView();
//          AddQualityToDatabase();
        }

        void AddQualityToDatabase()
        {
            selectedItem.Name = EditorGUILayout.TextField("Name: ", selectedItem.Name);
            if (selectedItem.Icon)
                selectedTexture = selectedItem.Icon.texture;
            else
                selectedTexture = null;

            if (GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
            {
                int controllerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controllerID);
            }

            string commandName = Event.current.commandName;

            if (commandName == "ObjectSelectorUpdated")
            {
                selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                Repaint();
            }

            if (GUILayout.Button("Save"))
            {
                if (selectedItem == null)
                    return;

                if (selectedItem.Name == "")
                    return;

                qualityDatabase.Add(selectedItem);

                selectedItem = new ISQuality();
            }
        }
    }
}
