using System;
using _01.Scripts.Pooling;
using UnityEngine;

namespace _01.Scripts.SO
{
    [CreateAssetMenu(fileName = "PoolItemSO", menuName = "Pooling/Item")]
    public class PoolItemSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public GameObject Item { get; private set; }
        [field:SerializeField] public int Count { get; private set; }

        private void OnValidate()
        {
            if (!Item.TryGetComponent<IPoolableItem>(out var item) && Item != null)
                Item = null;
        }
    }
}
