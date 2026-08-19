using System;
using UnityEngine;

namespace _01.Scripts.Player.Components
{
    public class PlayerBattery : MonoBehaviour
    {
        [SerializeField] private float battery;
        [SerializeField] private float maxBattery;
        private bool _isInBase;
        private Player _player;


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
            }
        }

        private void EnterBase()
        {
            _isInBase = true;
            battery = maxBattery;
        }

        private void ExitBase()
        {
            _isInBase = false;
        }
    }
}