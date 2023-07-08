using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class SpamCS : MonoBehaviour
    {
        [SerializeField] protected List<Transform> prefabs;

        private static SpamCS instance;
        public static SpamCS Instance => instance;

        private void Awake()
        {
            if (SpamCS.instance != null) Debug.LogError("Only 1 FXSpawner allow to exist");
            SpamCS.instance = this;
        }
        private void Reset()
        {
            LoadPrefab();
        }
        protected void LoadPrefab()
        {
            if (this.prefabs.Count > 0) return;
            foreach (Transform newp in transform)
            {
                prefabs.Add(newp);
            }
            this.HidePrefabs();
        }
        protected virtual void HidePrefabs()
        {
            foreach (Transform prefab in this.prefabs)
            {
                prefab.gameObject.SetActive(false);
            }
        }
        public virtual Transform Spam(string namePrefab, Transform holder, Vector3 posSpam)
        {
            Transform prefab = GetPrefabsByName(namePrefab);
            Transform newPrefab = Instantiate(prefab, posSpam, Quaternion.identity);
            newPrefab.name = prefab.name;
            newPrefab.SetParent(holder);
            newPrefab.gameObject.SetActive(true);
            return newPrefab;
        }

        public virtual Transform GetPrefabsByName(string prefabName)
        {
            foreach (Transform prefab in this.prefabs)
            {
                if (prefabName == prefab.name) return prefab;
            }
            return null;
        }
    }
}
