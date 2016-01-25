using UnityEditor;
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseEditor : EditorWindow
    {
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

        }

        void OnGUI()
        {
            TopTabBar();

            GUILayout.BeginHorizontal();
            ListView();
            ObjectDetails();
            GUILayout.EndHorizontal();
            BottomBar();
        }
    }
}