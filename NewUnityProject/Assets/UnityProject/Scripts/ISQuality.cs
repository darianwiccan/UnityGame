﻿using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    [System.Serializable]
    public class ISQuality : IISQuality, IISDatabaseObject
    {
        [SerializeField]
        string _name;
        [SerializeField]
        Sprite _icon;

        public ISQuality()
        {
            _name = "";
            _icon = new Sprite();
        }

        public ISQuality(string name, Sprite icon)
        {
            _name = name;
            _icon = icon;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Sprite Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public void Clone<T>(IISDatabaseObject item)
        {
            _name = item.Name;
            _icon = item.Icon;
        }

        public void OnGUI()
        {
            throw new System.NotImplementedException();
        }
    }
}