using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectCategory
    {
        protected ISArmorDatabase armorDatabase { get; set; }

        protected string dbName { get; set; }

        const string DB_PATH = @"Database";

        public ISObjectCategory()
        {
            dbName = @"ISArmorDB.asset";
        }

        public string DBFullPath
        {
            get { return @"Assets/" + DB_PATH + "/" + dbName; }
        }

        public void OnEnable()
        {
            if (armorDatabase == null)
                armorDatabase = ISArmorDatabase.GetDatabase<ISArmorDatabase>(DB_PATH, dbName);
        }

        public void OnGUI(Vector2 buttonSize, int _listViewWidth)
        {
//          ListView(buttonSize, _listViewWidth);
//          ItemDetails();
        }
    }
}