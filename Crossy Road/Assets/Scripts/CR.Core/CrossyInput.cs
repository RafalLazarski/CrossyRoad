using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace CR.InputSystem
{
	public class CrossyInput : MonoBehaviour
	{
		public Action<bool> isStartPressed;
		public Action<bool> isPausePressed;
		public Action<Vector2> isMovePressed;

		public void StartGame(CallbackContext ctx)
		{
			if (ctx.performed || ctx.canceled)
			{
				var val = ctx.ReadValueAsButton();
				isStartPressed?.Invoke(val);
            }
		}

		public void PauseGame(CallbackContext ctx)
		{
			if (ctx.performed || ctx.canceled)
			{
                var val = ctx.ReadValueAsButton();
                isPausePressed?.Invoke(val);
            }
		}

        public void Move(CallbackContext ctx)
        {
			if (ctx.performed || ctx.canceled)
			{
                var val = ctx.ReadValue<Vector2>();
				Debug.Log(val);
                isMovePressed?.Invoke(val);
            }
        }

		public void ClearAllInputs(CallbackContext ctx)
		{
			isMovePressed = null;
			isPausePressed = null;
			isStartPressed = null;

        }
    } 
}
