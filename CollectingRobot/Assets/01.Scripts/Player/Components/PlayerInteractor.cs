using System;
using UnityEngine;

namespace _01.Scripts.Player.Components
{
    public class PlayerInteractor : MonoBehaviour
    {
        private Player _player;
        
        public void Initialize(Player player)
        {
            _player = player;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            
        }
    }
}