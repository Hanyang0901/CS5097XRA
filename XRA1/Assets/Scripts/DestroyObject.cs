using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class DestroyObject : MonoBehaviour
{

    public InputActionReference inputActionReference;
    public AudioClip destroySFX;
    public ParticleSystem destroyVFX;


    MeshRenderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        inputActionReference.action.started += ToDestroy;
        
    }

    public void ToDestroy(InputAction.CallbackContext context)
    {
        if (GetComponent<XRGrabInteractable>().isSelected)
        {
            Instantiate(destroyVFX, transform.position, transform.rotation);
            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(destroySFX, transform.position);


        }
    }
}
