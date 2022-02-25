using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DuplicateObject : MonoBehaviour
{
    public InputActionReference inputActionReference;
    public AudioClip cloneSFX;


    Color currentColor;
    MeshRenderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        // add Cloned and Detached events to action's .started and .canceled states
        inputActionReference.action.started += Cloned;
        inputActionReference.action.canceled += Detached;

       
    }

    void Start()
    {
        
    }

    private void Cloned(InputAction.CallbackContext context)
    {
        // if the object is selected
        // instantiate a copy of the current gameObject in the current position/rotation

        if(GetComponent<XRGrabInteractable>().isSelected)
        {
            currentColor = GetComponent<HighlightObject>().GetOriginalColor();

            GameObject clonedObject = Instantiate(gameObject, transform.position, transform.rotation);

            clonedObject.GetComponent<MeshRenderer>().material.color = currentColor;
            clonedObject.GetComponent<HighlightObject>().ToggleHighlight();
            clonedObject.GetComponent<XRGrabInteractable>().forceGravityOnDetach = true;
            clonedObject.GetComponent<XRGrabInteractable>().throwOnDetach = true;

            AudioSource.PlayClipAtPoint(cloneSFX, transform.position);




        }

        // can specify custom behaviors for the clone here
        // can do additional things like playing an sfx
    }

    private void Detached(InputAction.CallbackContext context)
    {
        // can specify custom behaviors for the original object when detached
    }
}
