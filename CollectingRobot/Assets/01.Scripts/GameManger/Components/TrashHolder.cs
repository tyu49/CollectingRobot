using UnityEngine;

namespace _01.Scripts.GameManger.Components
{
    public class TrashHolder : MonoBehaviour
    {
        [field: SerializeField] public int HavingTrashes { get; private set; }


        public void GetTrashes(int value)
        {
            HavingTrashes += value;
        }

        public void UseTrash(int value)
        {
            HavingTrashes -= value;
        }
    }
}