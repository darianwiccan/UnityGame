#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    [System.Serializable]
    public class ISPotion : ISObject, IISPotion, IISGameObject
    {
        [SerializeField] int _effect;
        [SerializeField] GameObject _prefab;

        public PotionType potionType;

        public ISPotion()
        {
            _effect = 0;
            _prefab = null;

            potionType = PotionType.None;
        }

        public ISPotion(ISPotion potion)
        {
            Clone(potion);
        }

        public void Clone(ISPotion potion)
        {
            base.Clone(potion);

            _effect = potion.EffectAmount;
            potionType = potion.potionType;
            _prefab = potion.Prefab;
        }

        public GameObject Prefab
        {
            get
            { return _prefab; }
        }

        public int EffectAmount
        {
            get { return _effect; }
            set { _effect = value; }
        }

        //This code will go into a new sript later
#if UNITY_EDITOR
        public override void OnGUI()
        {
            base.OnGUI();
            _effect= EditorGUILayout.IntField("Effect Amount: ", _effect);
            DisplayPotionType();
            DisplayPrefab();
        }

        public void DisplayPotionType()
        {
            potionType = (PotionType)EditorGUILayout.EnumPopup("Potion Type", potionType);
        }

        public void DisplayPrefab()
        {
            _prefab = EditorGUILayout.ObjectField("Prefab: ", _prefab, typeof(GameObject), false) as GameObject;
        }
#endif
    }
}