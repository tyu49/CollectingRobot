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
        [SerializeField] private ParticleSystem jetPackEffect;
        [SerializeField] private ParticleSystem movingDustEffect;
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
            if(state && jetPackBattery > 0)
                jetPackEffect.Play();
            else
                jetPackEffect.Stop();
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
                if(jetPackBattery <= 0)
                    jetPackEffect.Stop();
            }

            if (!_player.IsOnGround && movingDustEffect.isPlaying)
            {
                movingDustEffect.Stop();
            }
            else if (_player.IsOnGround && _direction != 0 && !movingDustEffect.isPlaying)
            {
                movingDustEffect.Play();
            }
            else if (_direction == 0 && movingDustEffect.isPlaying)
            {
                movingDustEffect.Stop();
            }
        }

        private void EnterBase()
        {
            
        }
    }
}