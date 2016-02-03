using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace UnityProject.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject, new()
    {
        public void Add(T item)
        {
            database.Items.Add(item);
            EditorUtility.SetDirty(database);
        }

        public void Insert(int index, T item)
        {
            database.Items.Insert(index, item);
            EditorUtility.SetDirty(database);
        }

        public void Remove(T item)
        {
            database.Items.Remove(item);
            EditorUtility.SetDirty(database);
        }

        public void Remove(int index)
        {
            database.Items.RemoveAt(index);
            EditorUtility.SetDirty(database);
        }

        public void Replace(int index, T item)
        {
            database.Items[index] = item;
            EditorUtility.SetDirty(database);
        }

        public static U GetDatabase<U>(string dbPath, string dbName) where U : ScriptableObject
        {
            string dbFullPath = @"Assets/" + dbPath + "/" + dbName;

            U db = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(U)) as U;

            if (db == null)
            {
                if (!AssetDatabase.IsValidFolder(@"Assets/" + dbPath))
                {
                    AssetDatabase.CreateFolder(@"Assets", dbPath);
                    db = ScriptableObject.CreateInstance<U>() as U;
                    AssetDatabase.CreateAsset(db, dbFullPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
                else
                {
                    db = ScriptableObject.CreateInstance<U>() as U;
                    AssetDatabase.CreateAsset(db, dbFullPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
            }

            return db;
        }

        void LoadDatabase()
        {
            string dbFullPath = @"Assets/" + dbPath + "/" + dbName;

            database = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(D)) as D;

            if (database == null)
            {
                CreateDatabase(dbFullPath);
            }
        }

        void CreateDatabase(string dbFullPath)
        {
            if (!AssetDatabase.IsValidFolder(@"Assets/" + dbPath))
            {
                AssetDatabase.CreateFolder(@"Assets", dbPath);
                database = ScriptableObject.CreateInstance<D>() as D;
                AssetDatabase.CreateAsset(database, dbFullPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            else
            {
                database = ScriptableObject.CreateInstance<D>() as D;
                AssetDatabase.CreateAsset(database, dbFullPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }
}