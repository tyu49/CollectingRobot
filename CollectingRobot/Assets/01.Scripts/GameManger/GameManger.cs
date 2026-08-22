using System;
using _01.Scripts.GameManger.Components;
using UnityEngine;

namespace _01.Scripts.GameManger
{
    public class GameManger : MonoBehaviour
    {

        public static GameManger Instance { get; private set; }

        
        [SerializeField] private GameStarter starter;
        [SerializeField] private TrashHolder trash;
        [field : SerializeField] public PartManager Part { get; private set; }
        [field:SerializeField] public Vector3 LostThingPos { get; private set; }
        public int CurrentTrashes => trash.HavingTrashes;

        public event Action OnBaseCanvasOn;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            if (Instance == null)
                Instance = this;
            Part.Initialize(this);
        }

        private void OnDestroy()
        {
            if (Instance != null && Instance == this)
                Destroy(gameObject);
        }

        private void Start()
        {
            starter.GameStart();
        }

        public void GetTrashes(int value) => trash.GetTrashes(value);
        public void UseTrashed(int value) => trash.UseTrash(value);

        public void LandedOnGround()
        {
            starter.LandGround();
        }

        public void SetLostPos(Vector3 pos)
        {
            LostThingPos = pos;
        }

        public void EnterBase() => OnBaseCanvasOn?.Invoke();
    }
}