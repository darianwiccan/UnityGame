#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    [System.Serializable]
    public class ISArmor : ISObject, IISArmor, IISDestructable, IISGameObject
    {
        [SerializeField] int _curArmor;
        [SerializeField] int _maxArmor;
        [SerializeField] int _durability;
        [SerializeField] int _maxDurability;
        [SerializeField] GameObject _prefab;

        public EquipmentSlot equipmentSlot;

        public ISArmor(ISArmor armor)
        {
            Clone(armor);
        }

        public void Clone(ISArmor armor)
        {
            base.Clone(armor);

            _curArmor = armor._curArmor;
            _maxArmor = armor._maxArmor;
            _durability = armor.Durability;
            _maxDurability = armor.MaxDurability;
            equipmentSlot = armor.equipmentSlot;
            _prefab = armor.Prefab;
        }

        public ISArmor()
        {
            _curArmor = 0;
            _maxArmor = 0;
            _durability = 1;
            _maxDurability = 1;

            equipmentSlot = EquipmentSlot.Chest;
        }

        public Vector2 Armor
        {
            get
            {
                return new Vector2(_curArmor, _maxArmor);
            }
            set
            {
                if (value.x < 0)
                    value.x = 0;
                if (value.y < 1)
                    value.y = 1;
                if (value.x > value.y)
                    value.x = value.y;

                _curArmor = (int)value.x;
                _maxArmor = (int)value.y;
            }
        }

        public int Durability
        {
            get { return _durability; }
        }

        public int MaxDurability
        {
            get { return _maxDurability; }
        }

        public void TakeDamage(int amount)
        {
            _durability -= amount;

            if (_durability < 0)
                _durability = 0;

            if (_durability == 0)
                Break();
        }

        public void Repair()
        {
            _maxDurability--;

            if (_maxDurability > 0)
                _durability = _maxDurability;
        }

        public void Break()
        {
            _durability = 0;
        }

        public GameObject Prefab
        {
            get
            { return _prefab; }
        }

        //This code will go into a new sript later
#if UNITY_EDITOR
        public override void OnGUI()
        {
            base.OnGUI();
            _curArmor = EditorGUILayout.IntField("Cur Armor Value: ", _curArmor);
            _maxArmor = EditorGUILayout.IntField("Max Armor Value: ", _maxArmor);
            _durability = EditorGUILayout.IntField("Cur Durability: ", _durability);
            _maxDurability = EditorGUILayout.IntField("Max Durability: ", _maxDurability);
            DisplayEquipmentSlot();
            DisplayPrefab();
        }

        public void DisplayEquipmentSlot()
        {
            equipmentSlot = (EquipmentSlot)EditorGUILayout.EnumPopup("Equipment Slot", equipmentSlot);
        }

        public void DisplayPrefab()
        {
            _prefab = EditorGUILayout.ObjectField("Prefab: ", _prefab, typeof(GameObject), false) as GameObject;
        }
#endif
    }
}