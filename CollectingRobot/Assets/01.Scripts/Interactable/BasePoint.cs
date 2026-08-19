using UnityEngine;
namespace _01.Scripts.Interactable
{
    public class BasePoint : InteractableAbstract
    {
        private bool isEnter;
        private Player.Player _player;
        public override void Interact(Player.Player owner)
        {
            if (isEnter)
                return;
            _player = owner;
            _player.EnterBase();
        }

        public void ExitBase()
        {
            if (!isEnter)
                return;
            _player.ExitBase();
        }
    }
}