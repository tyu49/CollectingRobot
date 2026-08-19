using UnityEngine;

namespace _01.Scripts.Pooling
{
    public class InteractableUI : PoolableItemAbstract
    {
        [SerializeField] private float height;
        
        public override void Pop(Vector3 position)
        {
            transform.position = new UnityEngine.Vector3(position.x, position.y + height, position.z);
        }

        public override void Push()
        {
            PoolManager.Instance.Push(this);
        }
        
        
    }
}