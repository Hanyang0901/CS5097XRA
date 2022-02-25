using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class WandColorChange : MonoBehaviour
{

    public InputActionReference inputActionReference;
    public AudioClip wandColorChangeSFX;
    MeshRenderer _renderer;
    Color32 randomColor;



    void Awake()
    {
        inputActionReference.action.started += ChangeColor;
        _renderer = GetComponentInChildren<MeshRenderer>();

        

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor(InputAction.CallbackContext context)
    {
        if(GetComponent<XRGrabInteractable>().isSelected)
        {
            randomColor = GetRandomColour32();
            _renderer.material.color = randomColor;
            AudioSource.PlayClipAtPoint(wandColorChangeSFX, transform.position);
        }
    }
    private Color32 GetRandomColour32()
    {
        //using Color32
        return new Color32(
          (byte)UnityEngine.Random.Range(0, 255), //Red
          (byte)UnityEngine.Random.Range(0, 255), //Green
          (byte)UnityEngine.Random.Range(0, 255), //Blue
          255 //Alpha (transparency)
        );
    }
}
