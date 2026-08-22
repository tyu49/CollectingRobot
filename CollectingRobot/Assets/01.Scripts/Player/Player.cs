using System;
using _01.Scripts.Player.Components;
using _01.Scripts.SO;
using NUnit.Framework;
using UnityEngine;

namespace _01.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        //partsValue
        public float PartSpeed => partManager.PlusSpeed;
        public float PartJetPack => partManager.PlusJetPackGage;
        public float PartBattery => partManager.PlusBattery;
        public float PartInventory => partManager.PlusInventoryScale;
        public PartType PartType => partManager.EquippedType;
        
        //components
        [SerializeField] private InputReader inputReader;
        [SerializeField] private PlayerInteractor interactor;
        [SerializeField] private PlayerBattery battery;
        [SerializeField] private PlayerVisual visual;
        [SerializeField] private PlayerGroundChecker groundChecker;
        [SerializeField] private PlayerPartManager partManager;

        
        
        [field : SerializeField] public PlayerMover Mover{ get; private set; }
        [field : SerializeField] public PlayerTrashInventory TrashInventory { get; private set; }
        
        
        public event Action OnEnterBase;
        public event Action OnExitBase;
        private float _movingDirection;
        public bool IsOnGround { get; private set; }
        public float JetPackGage => 8 * Mover.JetPackBattery / Mover.JetPackMaxBattery;

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
            partManager = GetComponentInChildren<PlayerPartManager>();
            
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
        private void SetJetPackState(bool obj)
        {
            Mover.SetJetPackState(obj);
            visual.JetPackGage(obj);
        }

        private void Interact() => interactor.TryInteract();

        public void EnterBase()
        {
            OnEnterBase?.Invoke();
            gameObject.SetActive(false);
            GameManger.GameManger.Instance.GetTrashes(TrashInventory.PuttTrash());
        }

        public void ExitBase()
        {
            gameObject.SetActive(true);
            OnExitBase?.Invoke();
        }

        public void UseBattery(float value) => battery.UseBattery(value);
    }
}