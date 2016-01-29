using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    public class ISArmor : ISObject, IISArmor, IISDestructable, IISGameObject
    {
        [SerializeField] int _curArmor;
        [SerializeField] int _maxArmor;
        [SerializeField] int _durability;
        [SerializeField] int _maxDurability;
        [SerializeField] GameObject _prefab;

        public EquipmentSlot equipmentSlot;

        public ISArmor()
        {
            _curArmor = 0;
            _maxArmor = 0;
            _durability = 1;
            _maxDurability = 1;
            _prefab = new GameObject();

            equipmentSlot = EquipmentSlot.Chest;
        }

        public Vector2 Armor
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int Durability
        {
            get { throw new System.NotImplementedException(); }
        }

        public int MaxDurability
        {
            get { throw new System.NotImplementedException(); }
        }

        public void TakeDamage(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void Repair()
        {
            throw new System.NotImplementedException();
        }

        public void Break()
        {
            throw new System.NotImplementedException();
        }

        public GameObject Prefab
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}