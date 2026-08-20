using System;
using System.Collections;
using _01.Scripts.SO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _01.Scripts.Environment
{
    public class SteamPoint : MonoBehaviour
    {
        
        [SerializeField] private float disableTime;
        [SerializeField] private float activeTime;
        [SerializeField] private ParticleSystem particle;
        [SerializeField] private float power;
        [SerializeField] private LayerMask target;
        [SerializeField] private bool debug;
        [SerializeField] private BoxCollider2D collider;
        private bool _isActive;
        private WaitForSeconds StartDelay => new WaitForSeconds(Random.Range(0.1f, 10f));
        private WaitForSeconds ActiveTime => new WaitForSeconds(Random.Range(0.1f, activeTime));
        private WaitForSeconds DisableTime => new WaitForSeconds(Random.Range(0.1f, disableTime));
        private void Start()
        {
            StartCoroutine(EnableCo());
        }

        private IEnumerator DisableCo()
        {
            collider.enabled = false;
            _isActive = false;
            particle.Stop();
            yield return DisableTime;
            StartCoroutine(EnableCo());
        }
        private IEnumerator EnableCo()
        {
            _isActive = true;
            collider.enabled = true;
            particle.Play();
            yield return ActiveTime;
            StartCoroutine(DisableCo());
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!_isActive) return;
            if (other.TryGetComponent<Player.Player>(out var player))
            {
                player.Mover.ShootPlayer(power, Vector2.up, ForceMode2D.Force);
            }
        }
    }
}