using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pool 
{ 
    public class PoolMono<T> where T : MonoBehaviour
    {
        public T prefab { get; }
        public bool autoExpand { get; set; }
        public Transform container { get; }
        private List<T> pool;

        public PoolMono(T prefab, int count)
        {
            this.prefab = prefab;
            container = null;

            CreatePool(count);
        }

        public PoolMono(T prafab, int count, Transform container)
        {
            this.prefab = prafab;
            this.container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = UnityEngine.Object.Instantiate(prefab, container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var mono in pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;

            if (autoExpand)
                return CreateObject(true);

            throw new Exception($"There is no free element in pool of type {typeof(T)}");
        }
    }

}

