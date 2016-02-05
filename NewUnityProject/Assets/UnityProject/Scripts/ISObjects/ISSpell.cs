#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem
{
    [System.Serializable]
    public class ISSpell : ISObject, IISSpell, IISGameObject
    {
        [SerializeField] int _spellLevel;
        [SerializeField] int _manaCost;
        [SerializeField] int _cooldown;
        [SerializeField] int _spellRange;
        [SerializeField] GameObject _prefab;

        public SpellType spellType;

        public ISSpell()
        {
            _spellLevel = 1;
            _manaCost = 1;
            _cooldown = 1;
            _spellRange = 1;

            spellType = SpellType.None;
        }

        public ISSpell(ISSpell spell)
        {
            Clone(spell);
        }

        public void Clone(ISSpell spell)
        {
            base.Clone(spell);

            _spellLevel = spell.SpellLevel;
            _manaCost = spell.ManaCost;
            _cooldown = spell.Cooldown;
            _spellRange = spell.SpellRange;
            _prefab = spell.Prefab;
        }

        public int SpellLevel
        {
            get { return _spellLevel; }
            set { _spellLevel = value; }
        }

        public int ManaCost
        {
            get { return _manaCost; }
            set { _manaCost = value; }
        }

        public int Cooldown
        {
            get { return _cooldown; }
            set { _cooldown = value; }
        }

        public int SpellRange
        {
            get { return _spellRange; }
            set { _spellRange = value; }
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
            _spellLevel = EditorGUILayout.IntField("Spell Level: ", _spellLevel);
            _manaCost = EditorGUILayout.IntField("Mana Cost: ", _manaCost);
            _cooldown = EditorGUILayout.IntField("Cooldown Time: ", _cooldown);
            _spellRange = EditorGUILayout.IntField("Spell Range: ", _spellRange);
            DisplaySpellType();
            DisplayPrefab();
        }

        public void DisplaySpellType()
        {
            spellType = (SpellType)EditorGUILayout.EnumPopup("Spell Type", spellType);
        }

        public void DisplayPrefab()
        {
            _prefab = EditorGUILayout.ObjectField("Prefab: ", _prefab, typeof(GameObject), false) as GameObject;
        }
#endif
    }
}