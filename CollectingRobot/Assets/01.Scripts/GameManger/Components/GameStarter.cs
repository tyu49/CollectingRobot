using Unity.Cinemachine;
using UnityEngine;

namespace _01.Scripts.GameManger.Components
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera camera;
        [SerializeField] private Player.Player player;
        [SerializeField] private Transform baseTrm;
        [SerializeField] private Transform playerTrm;
        [SerializeField] private Canvas playerCanvas;
        [SerializeField] private Canvas baseCanvas;
        [SerializeField] private CinemachineImpulseSource impulseSource;
        public void GameStart()
        {
            playerCanvas.enabled = false;
            baseCanvas.enabled = false;
            player.EnterBase();
            camera.Target.TrackingTarget = baseTrm;
        }

        public void LandGround()
        {
            impulseSource.GenerateImpulse();
            playerCanvas.enabled = true;
            playerTrm.position = baseTrm.position;
            camera.Target.TrackingTarget = playerTrm;
            player.ExitBase();
            
            
        }
    }
}