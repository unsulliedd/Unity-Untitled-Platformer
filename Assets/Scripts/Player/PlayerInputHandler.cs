using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 HorizontalInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool AttackInput { get; private set; }


    public void OnMove(InputAction.CallbackContext context)
    {
        HorizontalInput = context.ReadValue<Vector2>().normalized;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
            JumpInput = true;

        if (context.canceled)
            JumpInput = false;
    }
    public void JumpInputHelper() => JumpInput = false;

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
            AttackInput = true;

        if (context.canceled)
            AttackInput = false;
    }
    public void AttackInputHelper() => AttackInput = false;
}
