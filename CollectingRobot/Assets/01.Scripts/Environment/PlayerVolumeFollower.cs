using UnityEngine;

namespace _01.Scripts.Environment
{
    public class PlayerVolumeFollower : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;

        private void LateUpdate()
        {
            if (playerTransform == null) return;

            transform.position = playerTransform.position;
        }
    }
}
