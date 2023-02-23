using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;
    private InputAction touchHoldAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions["TouchPosition"];

        touchPressAction = playerInput.actions["TouchPress"];
        touchHoldAction = playerInput.actions["TouchHold"];

    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
        touchHoldAction.performed += TouchHold;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
        touchHoldAction.canceled -= TouchHold;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed");

    }

    private void TouchHold(InputAction.CallbackContext context)
    {
        Debug.Log("Held");

    }

}
