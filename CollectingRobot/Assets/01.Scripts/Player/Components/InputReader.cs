using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _01.Scripts.Player.Components
{
    public class InputReader : MonoBehaviour, Control.IPlayerActions
    {
        public event Action<float> OnMovePressed;
        public event Action<bool> OnJumpPressed;
        public event Action OnInteractPressed;
        
        
        private Control _control;

        private void Awake()
        {
            _control = new Control();
            _control.Player.Enable();
            _control.Player.SetCallbacks(this);
        }

        private void OnDestroy()
        {
            _control.Disable();
            _control.Dispose();
        }
        
        
        

        public void OnMove(InputAction.CallbackContext context)
        {
            OnMovePressed?.Invoke(context.ReadValue<float>());
        }

        public void OnLook(InputAction.CallbackContext context)
        {
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if(context.performed)
                OnInteractPressed?.Invoke();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if(context.performed)
                OnJumpPressed?.Invoke(true);
            if(context.canceled)
                OnJumpPressed?.Invoke(false);
        }
    }
}
