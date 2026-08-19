using System;
using System.Collections.Generic;
using _01.Scripts.SO;
using UnityEngine;

namespace _01.Scripts.Pooling
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private PoolingListSO poolingList;

        private Dictionary<PoolItemSO, Stack<GameObject>> _poolingDic;
        public static PoolManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            if (Instance == null)
                Instance = this;
            _poolingDic = new Dictionary<PoolItemSO, Stack<GameObject>>();
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        private void Start()
        {
            if (poolingList == null)
            {
                Debug.LogError("There's no PoolingList in PoolManager");
                return;
            }
            foreach (var item in poolingList.List)
            {
                Stack<GameObject> stack = new Stack<GameObject>();
                    for (int i = 0; i < item.Count; i++)
                    {
                        GameObject go = Instantiate(item.Item, transform);
                        go.SetActive(false);
                        stack.Push(go);
                    }
                    _poolingDic.Add(item, stack);
            }
        }

        public PoolableItemAbstract Pop(Vector3 position, PoolItemSO request)
        {
            GameObject go = _poolingDic[request].Pop();
            go.SetActive(true);
            PoolableItemAbstract pool = go.GetComponent<PoolableItemAbstract>();
            pool.Pop(position);
            return pool;
        }


        public void Push(PoolableItemAbstract item)
        {
            item.gameObject.SetActive(false);
            _poolingDic[item.Item].Push(item.gameObject);
        }
    }
}