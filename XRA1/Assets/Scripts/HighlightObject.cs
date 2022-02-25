using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{

    public Color highlghtColor = Color.black;

    MeshRenderer _renderer;
    Color originalColor;
    bool isHighlighted;


    void Start()
    {
        // get a reference to the MeshRenderer
        _renderer = GetComponent<MeshRenderer>();
        // access and store the originalColor
        originalColor = _renderer.material.color;
    }

    void Highlight()
    {
        // set isHighlighted true
        isHighlighted = true;
        // change the material color to highlightColor
        _renderer.material.color = highlghtColor;
    }

    void Dehighlight()
    {
        // set isHighlighted false
        isHighlighted = false;
        // change the material color to originalColor
        _renderer.material.color = originalColor;
    }

    public void ToggleHighlight()
    {
        // if not already highlighted, highlight the object
        if(isHighlighted)
        {
            Dehighlight();
        }
        else
        {
            Highlight();
        }
        // else dehighlight it
    }

    public Color GetOriginalColor()
    {
        return originalColor;
    }
}
