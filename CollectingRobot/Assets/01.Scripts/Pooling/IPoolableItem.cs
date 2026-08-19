using System.Numerics;

namespace _01.Scripts.Pooling
{
    public interface IPoolableItem
    {
        void Pop(Vector3 position);
        void Push();
    }
}