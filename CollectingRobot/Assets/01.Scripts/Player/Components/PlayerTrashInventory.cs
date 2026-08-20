using UnityEngine;

namespace _01.Scripts.Player.Components
{
    public class PlayerTrashInventory : MonoBehaviour
    {
        [SerializeField] private int maxCapacity;
        [field : SerializeField] public int CurrentCapacity { get; private set; }
        private Player _player;

        public void Initialize(Player player)
        {
            _player = player;
        }

        public void GetTrash(Trash.Trash trash)
        {
            if (CurrentCapacity >= maxCapacity)
                return;
            trash.Pickup();
            CurrentCapacity++;
            if (CurrentCapacity >= maxCapacity)
                CurrentCapacity = maxCapacity;
        }
    }
}