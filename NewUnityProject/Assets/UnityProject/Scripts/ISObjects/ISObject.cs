#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    [System.Serializable]
    public class ISObject : IISObject
    {
        [SerializeField] string _name;
        [SerializeField] Sprite _icon;
        [SerializeField] int _value;
        [SerializeField] int _burden;
        [SerializeField] ISQuality _quality;

        public ISObject() { }

        public ISObject(ISObject item)
        {
            Clone(item);
        }

        public void Clone(ISObject item)
        {
            _name = item.ISOName;
            _icon = item.ISOIcon;
            _value = item.ISOValue;
            _burden = item.ISOBurden;
            _quality = item.ISOQuality;
        }

        public void Clone(IISDatabaseObject item)
        {
            _name = item.Name;
            _icon = item.Icon;
        }

        public string ISOName
        {
            get { return _name; }
            set { _name = value; }
        }

        public Sprite ISOIcon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public int ISOValue
        {
            get { return _value; }
            set { _value = value; }
        }

        public int ISOBurden
        {
            get { return _burden; }
            set { _burden = value; }
        }

        public ISQuality ISOQuality
        {
            get { return _quality; }
            set { _quality = value; }
        }

        //This code is going to be placed in a new clas later on
#if UNITY_EDITOR
        int qualitySelectedIndex = 0;
        ISQualityDatabase qdb;
        string[] option;
        bool qualityDatabaseLoaded = false;

        public virtual void OnGUI()
        {
            GUILayout.BeginVertical();
            _name = EditorGUILayout.TextField("Name: ", _name);
            _value = EditorGUILayout.IntField("Value: ", _value);
            _burden = EditorGUILayout.IntField("Burden: ", _burden);
            DisplayIcon();
            DisplayQuality();
            GUILayout.EndVertical();
        }

        public void DisplayIcon()
        {
            _icon = EditorGUILayout.ObjectField("Icon: ", _icon, typeof(Sprite), false) as Sprite;
        }

        public int selectedQualityID
        {
            get { return qualitySelectedIndex; }
        }

        public void LoadQualityDatabase()
        {
            string DB_NAME = @"ISQualityDB.asset";
            string DB_PATH = @"Database";

            qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DB_PATH, DB_NAME);

            option = new string[qdb.Count];

            for (int i = 0; i < qdb.Count; i++)
            {
                option[i] = qdb.Get(i).Name;
            }

            qualityDatabaseLoaded = true;
        }

        public void DisplayQuality()
        {
        if (!qualityDatabaseLoaded)
        {
            LoadQualityDatabase();
            return;
        }
            int itemIndex = 0;
            if (_quality != null)
                itemIndex = qdb.GetIndex(_quality.Name);

            if (itemIndex == -1)
                itemIndex = 0;

            qualitySelectedIndex = EditorGUILayout.Popup("Quality", itemIndex, option);
            _quality = qdb.Get(selectedQualityID);
        }

#endif

    }
}