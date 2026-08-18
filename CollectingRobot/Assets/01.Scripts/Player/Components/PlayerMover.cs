using System;
using UnityEngine;

namespace _01.Scripts.Player.Components
{
    public class PlayerMover : MonoBehaviour
    {
        private Player _player;

        private float Speed => _player.Speed;
        private float JumpForce => _player.JumpForce;
        private Rigidbody2D Rb => _player.Rb;

        private float _direction;
        
        public void Initialize(Player player)
        {
            _player = player;
        }

        public void Move(float direction)
        {
            _direction = direction;
        }


        private void FixedUpdate()
        {
            Rb.linearVelocityX = _direction * Speed;
        }
    }
}