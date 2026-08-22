using System;
using UnityEngine;
using UnityEngine.UI;

namespace _01.Scripts.Player.Components
{
    public class PlayerBattery : MonoBehaviour
    {
        [SerializeField] private float defaultBattery;
        [SerializeField] private float battery;
        [SerializeField] private RectTransform batteryGage;
        private float MaxBattery => defaultBattery + _player.PartBattery;
        private bool _isInBase;
        private Player _player;
        private float Height => 150f * (battery / MaxBattery);


        public void Initialize(Player player)
        {
            _player = player;
            _player.OnEnterBase += EnterBase;
            _player.OnExitBase += ExitBase;
        }


        private void OnDestroy()
        {
            
            _player.OnEnterBase -= EnterBase;
            _player.OnExitBase -= ExitBase;
        }

        private void Update()
        {
            if (!_isInBase)
            {
                battery -= Time.deltaTime;
                if (battery <= 0)
                {
                    Debug.Log("사망");
                }
            }
            batteryGage.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Height);

            

        }

        private void EnterBase()
        {
            _isInBase = true;
        }

        private void ExitBase()
        {
            battery = MaxBattery;
            _isInBase = false;
        }

        public void UseBattery(float value)
        {
            battery -= value;
        }
    }
}