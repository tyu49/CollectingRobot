using System;
using UnityEngine;

namespace _01.Scripts.Player.Components
{
    public class PlayerMover : MonoBehaviour
    {
        private Player _player;

        [SerializeField]private float speed;
        [SerializeField]private float jetPackPower;
        [SerializeField]private float jetPackPowerLimit;
        [SerializeField]private float jetPackBattery;
        private Rigidbody2D _rb;

        private float _direction;
        private bool _jetPackState;
        
        public void Initialize(Player player)
        {
            _player = player;
            _rb = GetComponentInParent<Rigidbody2D>();
        }

        public void SetMovement(float direction)
        {
            _direction = direction;
        }
        public void SetJetPackState(bool state)
        {
            _jetPackState = state;
        }

        private void FixedUpdate()
        {
            _rb.linearVelocityX = _direction * speed;
            if (_jetPackState && jetPackBattery > 0)
            {
                _rb.AddForceY(jetPackPower, ForceMode2D.Force);
                jetPackBattery -= Time.fixedDeltaTime;
                if (_rb.linearVelocityY >= jetPackPowerLimit)
                    _rb.linearVelocityY = jetPackPowerLimit;
            }
        }

        private void EnterBase()
        {
            
        }
    }
}