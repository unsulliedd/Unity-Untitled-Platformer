using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 HorizontalInput { get; private set; }

    public void OnMove(InputAction.CallbackContext context)
    {
        HorizontalInput = context.ReadValue<Vector2>().normalized;
    }
}
