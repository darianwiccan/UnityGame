using UnityEditor;
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

        public virtual void OnGUI()
        {
            GUILayout.BeginVertical();
            _name = EditorGUILayout.TextField("Name: ", _name);
            _value = System.Convert.ToInt32(EditorGUILayout.TextField("Value: ", _value.ToString()));
            _burden = System.Convert.ToInt32(EditorGUILayout.TextField("Burden: ", _burden.ToString()));
            DisplayIcon();
            DisplayQuality();
            GUILayout.EndVertical();
        }

        public void DisplayIcon()
        {
            GUILayout.Label("Icon");
        }

        public void DisplayQuality()
        {
            GUILayout.Label("Quality");
        }
    }
}