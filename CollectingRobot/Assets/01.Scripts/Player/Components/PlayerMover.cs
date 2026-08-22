using System;
using _01.Scripts.SO;
using UnityEngine;

namespace _01.Scripts.Player.Components
{
    public class PlayerMover : MonoBehaviour
    {
        private Player _player;

        [SerializeField]private float speed;
        [SerializeField]private float jetPackPower;
        [SerializeField]private float jetPackPowerLimit;
        [field : SerializeField]public float JetPackBattery { get; private set; }
        [field : SerializeField]public float JetPackDefaultBattery{ get; private set; }
        public float JetPackMaxBattery => JetPackDefaultBattery + _player.PartJetPack;
        [SerializeField] private ParticleSystem jetPackEffect;
        [SerializeField] private ParticleSystem movingDustEffect;
        private Rigidbody2D _rb;

        private float _direction;
        private bool _jetPackState;
        
        public void Initialize(Player player)
        {
            _player = player;
            _rb = GetComponentInParent<Rigidbody2D>();
            _player.OnExitBase += ExitBase;
        }

        private void OnDestroy()
        {
            _player.OnExitBase -= ExitBase;
        }

        public void SetMovement(float direction)
        {
            _direction = direction;
        }
        public void SetJetPackState(bool state)
        {
            _jetPackState = state;
            if(state && (JetPackBattery > 0 || _player.PartType.HasFlag(PartType.BatteryRecycle)))
                jetPackEffect.Play();
            else
                jetPackEffect.Stop();
        }

        public void ShootPlayer(float power, Vector2 direction, ForceMode2D type)
        {
            _rb.AddForce(power*direction.normalized, type);
        }

        private void FixedUpdate()
        {
            _rb.linearVelocityX = _direction * speed;
            if (_jetPackState && JetPackBattery > 0)
            {
                _rb.AddForceY(jetPackPower, ForceMode2D.Force);
                JetPackBattery -= Time.fixedDeltaTime;
                if (_rb.linearVelocityY >= jetPackPowerLimit)
                    _rb.linearVelocityY = jetPackPowerLimit;
                if(JetPackBattery <= 0 && !_player.PartType.HasFlag(PartType.BatteryRecycle))
                    jetPackEffect.Stop();
            }
            else if (JetPackBattery <= 0 && _player.PartType.HasFlag(PartType.BatteryRecycle) && _jetPackState)
            {
                _player.UseBattery(Time.fixedDeltaTime * 5);
                _rb.AddForceY(jetPackPower, ForceMode2D.Force);
                if (_rb.linearVelocityY >= jetPackPowerLimit)
                    _rb.linearVelocityY = jetPackPowerLimit;
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

        private void ExitBase()
        {
            JetPackBattery = JetPackMaxBattery;
            if(_jetPackState)
                jetPackEffect.Play();
        }
    }
}