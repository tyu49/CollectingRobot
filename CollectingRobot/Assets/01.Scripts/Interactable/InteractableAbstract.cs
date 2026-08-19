
using _01.Scripts.Player.Components;
using _01.Scripts.Pooling;
using _01.Scripts.SO;
using UnityEngine;

namespace _01.Scripts.Interactable
{
    public abstract class InteractableAbstract : MonoBehaviour
    {
        [SerializeField] private PoolItemSO interactableUI;

        private PoolableItemAbstract _currentUI;
        public virtual void Interact(Player.Player owner)
        {
        }

        public virtual void EnableInteractableUI()
        {
            _currentUI = PoolManager.Instance.Pop(transform.position, interactableUI).GetComponent<PoolableItemAbstract>();
        }
        public virtual void DisableInteractableUI()
        {
            _currentUI.Push();
        }
    }
}