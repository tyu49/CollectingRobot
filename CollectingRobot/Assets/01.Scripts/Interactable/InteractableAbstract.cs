
using _01.Scripts.Player.Components;
using _01.Scripts.Pooling;
using _01.Scripts.SO;
using UnityEngine;

namespace _01.Scripts.Interactable
{
    public abstract class InteractableAbstract : MonoBehaviour
    {

        private PoolableItemAbstract _currentUI;
        protected Player.Player Player;
        public virtual void Interact(Player.Player owner)
        {
            Player = owner;
        }

        public virtual void EnableInteractableUI()
        {
        }
        public virtual void DisableInteractableUI()
        {
        }
    }
}