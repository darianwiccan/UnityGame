#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    [System.Serializable]
    public class ISWeapon : ISObject, IISWeapon, IISDestructable, IISGameObject
    {
        [SerializeField] int _minDamage;
        [SerializeField] int _durability;
        [SerializeField] int _maxDurability;
        [SerializeField] GameObject _prefab;

        public EquipmentSlot equipmentSlot;


        public ISWeapon()
        {
            _minDamage = 0;
            _durability = 1;
            _maxDurability = 1;
            _prefab = null;

            equipmentSlot = EquipmentSlot.Weapon;
        }

        public ISWeapon(ISWeapon weapon)
        {
            Clone(weapon);
        }

        public void Clone(ISWeapon weapon)
        {
            base.Clone(weapon);

            _minDamage = weapon.MinDamage;
            _durability = weapon.Durability;
            _maxDurability = weapon.MaxDurability;
            equipmentSlot = weapon.equipmentSlot;
            _prefab = weapon.Prefab;
        }

        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }

        public int Attack()
        {
            throw new System.NotImplementedException();
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
            get { return _prefab; }
        }

        //This code will go into a new sript later
#if UNITY_EDITOR
        public override void OnGUI()
        {
            base.OnGUI();
            _minDamage = EditorGUILayout.IntField("Min Damage: ", _minDamage);
            _durability = EditorGUILayout.IntField("Durability: ", _durability);
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