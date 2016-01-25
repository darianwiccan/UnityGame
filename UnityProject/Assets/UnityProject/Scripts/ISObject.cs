using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    [System.Serializable]
    public class ISObject : IISObject
    {
        [SerializeField]
        string _name;
        [SerializeField]
        Sprite _icon;
        [SerializeField]
        int _value;
        [SerializeField]
        int _burden;
        [SerializeField]
        ISQuality _quality;

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
    }
}