using UnityEngine;
using System.Collections;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject, new()
    {
        Vector2 _scrollPos = Vector2.zero;
        int _selectedIndex = -1;
        T tempItem;
        bool showDetails = false;

        public void ListView(Vector2 buttonSize, int _listViewWidth)
        {
            _scrollPos = GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

            for (int i = 0; i < database.Count; i++)
            {
                if (GUILayout.Button(database.Get(i).ISOName, "box", GUILayout.Width(buttonSize.x), GUILayout.Height(buttonSize.y)))
                {
                    if (showDetails)
                        return;
                    _selectedIndex = i;
                    tempItem = new T();
                    tempItem.Clone(database.Get(i));
                    showDetails = true;
                }
            }
            GUILayout.EndScrollView();
        }
    }
}
