using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject, new()
    {
        [SerializeField] D database;
        [SerializeField] string dbName;
        [SerializeField] string dbPath = @"Database";
        public string strItemType = "Item";

        public ISObjectDatabaseType(string curDB)
        {
            dbName = curDB;
        }

        public void OnEnable(string itemType)
        {
            strItemType = itemType;
            if (database == null)
                LoadDatabase();
        }

        public void OnGUI(Vector2 buttonSize, int _listViewWidth)
        {
            ListView(buttonSize, _listViewWidth);
            ItemDetails();
        }
    }
}