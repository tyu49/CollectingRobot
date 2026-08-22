using System;
using UnityEngine;
namespace _01.Scripts.Interactable
{
    public class BasePoint : InteractableWithUI
    {
        private bool _isEnter;
        private Player.Player _player;
        [SerializeField] private Canvas baseCanvas;
        [SerializeField] private Canvas nonBaseCanvas;
        [SerializeField] private LayerMask target;
        [SerializeField] private ParticleSystem dust;
        [SerializeField] private ParticleSystem explosionDust1;
        [SerializeField] private ParticleSystem explosionDust2;

        private bool _started;
        public override void Interact(Player.Player owner)
        {
            if (_isEnter)
                return;
            _player = owner;
            _player.EnterBase();
            _isEnter = true;
            baseCanvas.enabled = true;
            nonBaseCanvas.enabled = false;
            GameManger.GameManger.Instance.EnterBase();
        }

        public void ExitBase()
        {
            if (!_isEnter)
                return;
            _player.ExitBase();
            baseCanvas.enabled = false;
            nonBaseCanvas.enabled = true;
            _isEnter = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_started) return;
            explosionDust1.Play();
            explosionDust2.Play();
            dust.Stop();
            GameManger.GameManger.Instance.LandedOnGround();
            _started = true;
        }

        private void Start()
        {
            dust.Play();
        }
    }
}