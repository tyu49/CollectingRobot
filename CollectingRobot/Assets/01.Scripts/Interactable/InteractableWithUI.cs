using _01.Scripts.Pooling;
using _01.Scripts.SO;
using UnityEngine;

namespace _01.Scripts.Interactable
{
    public class InteractableWithUI : InteractableAbstract
    {
        [SerializeField] private PoolItemSO interactableUI;

        private PoolableItemAbstract _currentUI;
        public override void Interact(Player.Player owner)
        {
        }

        public override void EnableInteractableUI()
        {
            _currentUI = PoolManager.Instance.Pop(transform.position, interactableUI).GetComponent<PoolableItemAbstract>();
        }
        public override void DisableInteractableUI()
        {
            _currentUI.Push();
        }
    }
}