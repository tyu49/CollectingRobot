using System;
using _01.Scripts.Player.Components;
using UnityEngine;

namespace _01.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Player : MonoBehaviour
    {
        //components
        [SerializeField] private PlayerMover mover;
        [SerializeField] private InputReader inputReader;
        [SerializeField] private PlayerInteractor interactor;
        [SerializeField] private PlayerBattery battery;
        
        private void Reset()
        {
            mover = GetComponentInChildren<PlayerMover>();
            inputReader = GetComponentInChildren<InputReader>();
            interactor = GetComponentInChildren<PlayerInteractor>();
            battery = GetComponentInChildren<PlayerBattery>();
            
        }

        private void Awake()
        {
            mover.Initialize(this);
            interactor.Initialize(this);
            inputReader.OnMovePressed += SetMoveDirection;
            inputReader.OnJumpPressed += SetJetPackState;
        }

        private void OnDestroy()
        {
            inputReader.OnMovePressed -= SetMoveDirection;
            inputReader.OnJumpPressed -= SetJetPackState;
        }

        private void SetMoveDirection(float obj) => mover.SetMovement(obj);
        private void SetJetPackState(bool obj) => mover.SetJetPackState(obj);
    }
}