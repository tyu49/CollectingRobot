using System;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace _01.Scripts.Player.Components
{
    public class PlayerVisual : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer jetpackGageUI;
        [SerializeField] private float jetpackGageDelay;
        [SerializeField] private Volume shadowVolume;
        [SerializeField] private Vignette shadow;
        [SerializeField] private float shadowDelay;
        [SerializeField] private float limitDepth = 0f;
        [SerializeField] private float underShadow;
        [SerializeField] private float overShadow;
        private Player _player;
        private Transform _trm;
        private bool _isInUnderGround;
        private bool _hasNightVision;
        private  int VelocityHash => Animator.StringToHash("Velocity");
        private  int IsGroundHash => Animator.StringToHash("IsGround");

        public void Initialize(Player owner, Transform trm)
        {
            _player = owner;
            _trm = trm;
            shadowVolume.profile.TryGet(out shadow);
        }

        public void MovingAnimation(float value)
        {
            animator.SetFloat(VelocityHash, Mathf.Abs(value));
            animator.SetBool(IsGroundHash, _player.IsOnGround);
        }

        private void Update()
        {
            jetpackGageUI.size = new Vector2(0.6f, _player.JetPackGage);
        }

        public void JetPackGage(bool situation)
        {
            jetpackGageUI.DOFade(situation ? 1 : 0, jetpackGageDelay);
        }

        private void FixedUpdate()
        {
            if (_trm.position.y <= limitDepth && !_isInUnderGround)
            {
                _isInUnderGround = true;
                DOTween.To(() => shadow.intensity.value, x => shadow.intensity.value = x, underShadow, shadowDelay)
                    .SetEase(Ease.OutCirc);
            }
            if (_trm.position.y > limitDepth && _isInUnderGround)
            {
                _isInUnderGround = false;
                DOTween.To(() => shadow.intensity.value, x => shadow.intensity.value = x, overShadow, shadowDelay)
                    .SetEase(Ease.OutCirc);
            }
        }
    }
}