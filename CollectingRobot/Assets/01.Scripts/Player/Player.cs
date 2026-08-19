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
        [SerializeField] private PlayerVisual visual;

        public event Action OnEnterBase;
        public event Action OnExitBase;
        private float _movingDirection;

        private void FixedUpdate()
        {
            if (_movingDirection != 0)
            {
                transform.rotation = new Quaternion(0, _movingDirection == 1 ? 0 : 180, 0, 0);
            }
            visual.MovingAnimation(_movingDirection);
        }


        private void Reset()
        {
            mover = GetComponentInChildren<PlayerMover>();
            inputReader = GetComponentInChildren<InputReader>();
            interactor = GetComponentInChildren<PlayerInteractor>();
            battery = GetComponentInChildren<PlayerBattery>();
            visual = GetComponentInChildren<PlayerVisual>();
            
        }

        private void Awake()
        {
            mover.Initialize(this);
            interactor.Initialize(this);
            battery.Initialize(this);
            visual.Initialize(this, transform);
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
            mover.SetMovement(obj);   
        }
        private void SetJetPackState(bool obj) => mover.SetJetPackState(obj);
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