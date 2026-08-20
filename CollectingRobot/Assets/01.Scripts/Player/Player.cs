using System;
using _01.Scripts.Player.Components;
using NUnit.Framework;
using UnityEngine;

namespace _01.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Player : MonoBehaviour
    {
        //components
        [SerializeField] private InputReader inputReader;
        [SerializeField] private PlayerInteractor interactor;
        [SerializeField] private PlayerBattery battery;
        [SerializeField] private PlayerVisual visual;
        [SerializeField] private PlayerGroundChecker groundChecker;

        
        
        [field : SerializeField] public PlayerMover Mover{ get; private set; }
        [field : SerializeField] public PlayerTrashInventory TrashInventory { get; private set; }
        public event Action OnEnterBase;
        public event Action OnExitBase;
        private float _movingDirection;
        public bool IsOnGround { get; private set; }

        private void FixedUpdate()
        {
            if (_movingDirection != 0)
            {
                transform.rotation = new Quaternion(0, _movingDirection == 1 ? 0 : 180, 0, 0);
            }
            visual.MovingAnimation(_movingDirection);
            IsOnGround = groundChecker.Check();
        }


        private void Reset()
        {
            Mover = GetComponentInChildren<PlayerMover>();
            inputReader = GetComponentInChildren<InputReader>();
            interactor = GetComponentInChildren<PlayerInteractor>();
            battery = GetComponentInChildren<PlayerBattery>();
            visual = GetComponentInChildren<PlayerVisual>();
            groundChecker = GetComponentInChildren<PlayerGroundChecker>();
            TrashInventory = GetComponentInChildren<PlayerTrashInventory>();
            
        }

        private void Awake()
        {
            Mover.Initialize(this);
            interactor.Initialize(this);
            battery.Initialize(this);
            visual.Initialize(this, transform);
            groundChecker.Initialize(this);
            TrashInventory.Initialize(this);
            inputReader.OnMovePressed += SetMoveDirection;
            inputReader.OnJumpPressed += SetJetPackState;
            inputReader.OnInteractPressed += Interact;
        }   

        private void OnDestroy()
        {
            inputReader.OnMovePressed -= SetMoveDirection;
            inputReader.OnJumpPressed -= SetJetPackState;
            inputReader.OnInteractPressed -= Interact;
        }

        private void SetMoveDirection(float obj)
        {
            _movingDirection = obj;
            Mover.SetMovement(obj);   
        }
        private void SetJetPackState(bool obj) => Mover.SetJetPackState(obj);
        private void Interact() => interactor.TryInteract();

        public void EnterBase()
        {
            OnEnterBase?.Invoke();
            gameObject.SetActive(false);
        }

        public void ExitBase()
        {
            gameObject.SetActive(true);
            OnExitBase?.Invoke();
        }
    }
}