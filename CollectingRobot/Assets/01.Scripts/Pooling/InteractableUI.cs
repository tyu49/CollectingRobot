using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace _01.Scripts.Pooling
{
    public class InteractableUI : MonoBehaviour, IPoolableItem
    {
        [SerializeField] private float height;
        
        public void Pop(Vector3 position)
        {
            transform.position = new UnityEngine.Vector3(position.X, position.Y + height, position.Z);
        }

        public void Push()
        {
        }
        
        
    }
}