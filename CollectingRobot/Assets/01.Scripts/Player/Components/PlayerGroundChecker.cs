using System;
using UnityEngine;

namespace _01.Scripts.Player.Components
{
    public class PlayerGroundChecker : MonoBehaviour
    {
        private Player _player;
        [SerializeField] private Vector2 offset;
        [SerializeField] private Vector2 size;
        [SerializeField] private LayerMask target;
        [SerializeField] private bool debug;
        private Vector2 Offset => offset + (Vector2)transform.position;
        
        public void Initialize(Player player)
        {
            _player = player;
        }

        public bool Check() => Physics2D.OverlapBox(Offset, size, 0f, target);

        private void OnDrawGizmos()
        {
            if (!debug) return;
            Gizmos.color = Color.yellowNice;
            Gizmos.DrawWireCube(Offset, size);
        }
    }
}