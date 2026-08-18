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
        [SerializeField] private PlayerMover mover;
        [SerializeField] private InputReader inputReader;
        public Rigidbody2D Rb { get; private set; }

        private void Reset()
        {
            mover = GetComponentInChildren<PlayerMover>();
            inputReader = GetComponentInChildren<InputReader>();
            
        }

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            mover.Initialize(this);
            inputReader.OnMovePressed += SetMoveDirection;
        }

        private void SetMoveDirection(float obj) => mover.Move(obj);
    }
}