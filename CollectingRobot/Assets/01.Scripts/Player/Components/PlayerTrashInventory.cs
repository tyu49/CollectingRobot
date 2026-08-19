using UnityEngine;

namespace _01.Scripts.Player.Components
{
    public class PlayerTrashInventory : MonoBehaviour
    {
        [SerializeField] private int maxCapacity;
        [field : SerializeField] public int CurrentCapacity { get; private set; }
        private Player _player;
    }
}