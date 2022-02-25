using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// to be attached to the controller for which you want to toggle RayInteractor
/// switches between RayInteractor and DirectInteractor
/// </summary>
public class ToggleRay : MonoBehaviour
{
    // define a public InputActionReference for toggle button
    // and a reference to the rayInteractor GameObject to be toggled
    public InputActionReference toggleInputReference;
    public GameObject rayInteractor;

    // need a global variable for the XRDirectInteractor reference
    XRDirectInteractor directInteractor;
    void Awake()
    {
        toggleInputReference.action.started += Pressed;
        toggleInputReference.action.canceled += Released;

        directInteractor = GetComponent<XRDirectInteractor>();

    }

    private void OnDestroy()
    {
        // remove event listeners when destroyed
    }

    void Pressed(InputAction.CallbackContext context)
    {
        // toggle the Ray 
        Toggle();
    }

    void Released(InputAction.CallbackContext context)
    {
        // toggle the Ray
        Toggle();
    }

    void Toggle()
    {
        // get a bool, isToggled, for the current state of the rayInteractor
        // setActive of the rayInteractor based on the bool value
        // set enable of the directInteractor based on the bool value

        bool isToggled = !rayInteractor.gameObject.activeSelf;
        rayInteractor.SetActive(isToggled);
        directInteractor.enabled = !isToggled;
    }
}
