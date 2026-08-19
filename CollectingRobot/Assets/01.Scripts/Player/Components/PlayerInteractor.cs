using System;
using _01.Scripts.Interactable;
using UnityEngine;

namespace _01.Scripts.Player.Components
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private ContactFilter2D target;

        private Collider2D[] _results;
        private Player _player;
        
        public void Initialize(Player player)
        {
            _player = player;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent<InteractableAbstract>(out var interact))
            {
                interact.EnableInteractableUI();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.TryGetComponent<InteractableAbstract>(out var interact))
            {
                interact.DisableInteractableUI();
            }
        }

        private void TryInteract()
        {
            int counts = Physics2D.OverlapCircle(transform.position, radius, target, _results);
            if (counts <= 0)
                return;
            var distance = float.MaxValue;
            InteractableAbstract closestInteractor = null;
            for (var i = 0; i < counts; i++)
            {
                var collider = _results[i];
                if(!collider.TryGetComponent<InteractableAbstract>(out var interact))
                    continue;
                var currentDistance = collider.transform.position.magnitude - transform.position.magnitude;
                if (currentDistance < distance)
                {
                    distance = currentDistance;
                    closestInteractor = collider.GetComponent<InteractableAbstract>();
                }
            }
            
            closestInteractor.Interact(_player);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.dodgerBlue;
            Gizmos.DrawWireSphere(transform.position, radius);
            Gizmos.color = Color.red;
        }
    }
}