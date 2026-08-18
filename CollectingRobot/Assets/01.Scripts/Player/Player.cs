using System;
using _01.Scripts.Player.Components;
using UnityEngine;

namespace _01.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Player : MonoBehaviour
    {
        //value
        [field : SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
        
        
        //components
        private PlayerMover _mover;
        private InputReader _inputReader;
        public Rigidbody2D Rb { get; private set; }

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            _mover = GetComponentInChildren<PlayerMover>();
            _inputReader = GetComponentInChildren<InputReader>();
            
        }
    }
}