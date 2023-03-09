using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankButtonController : MonoBehaviour
{

    public InputAction touchAction;
    public float holdDuration = 1.0f;

    private float touchHoldValue = 0.0f;
    private bool isTouchHeld = false;

    private void OnEnable()
    {
        touchAction.Enable();
    }

    private void OnDisable()
    {
        touchAction.Disable();
    }

    private void Update()
    {
        touchHoldValue = touchAction.ReadValue<float>();

        if (touchHoldValue == 1.0f && !isTouchHeld)
        {
            isTouchHeld = true;
            Debug.Log("Touch held!");
        }
        else if (touchHoldValue == 0.0f && isTouchHeld)
        {
            isTouchHeld = false;
            Debug.Log("Touch released!");
        }
    }


}
