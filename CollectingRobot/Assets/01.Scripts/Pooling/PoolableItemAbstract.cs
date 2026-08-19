
using _01.Scripts.SO;
using UnityEngine;

namespace _01.Scripts.Pooling
{
    public abstract class PoolableItemAbstract : MonoBehaviour
    {
        [field : SerializeField] public PoolItemSO Item { get; private set; }
        public abstract void Pop(Vector3 position);
        public abstract void Push();
    }
}