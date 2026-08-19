using UnityEngine;

namespace _01.Scripts.Player.Components
{
    public class PlayerVisual : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private Player _player;
        private Transform _trm;
        private  int VelocityHash => Animator.StringToHash("Velocity");

        public void Initialize(Player owner, Transform trm)
        {
            _player = owner;
            _trm = trm;
        }

        public void MovingAnimation(float value)
        {
            animator.SetFloat(VelocityHash, Mathf.Abs(value));
        }
    }
}