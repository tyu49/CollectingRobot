using UnityEngine;

namespace _01.Scripts.Interactable
{
    public class TestInteract : InteractableAbstract
    {
        public override void Interact(Player.Player owner)
        {
            Debug.Log("interacted");
        }
    }
}