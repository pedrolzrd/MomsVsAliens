using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarState : MonoBehaviour
{
    public Sprite imageActive;
    public Sprite imageInactive;
    private Image imageComponent;
    private bool isActive = true;
    

    void Start()
    {
        imageComponent = GetComponent<Image>();
        UpdateImage();
    }

    public void ToggleState()
    {
        isActive = !isActive;
        UpdateImage();
    }

    public void Active()
    {
        isActive = true;
        UpdateImage();
    }

    public void Inactive()
    {
        isActive = false;
        UpdateImage();
    }

    private void UpdateImage()
    {
        if (isActive)
        {
            imageComponent.sprite = imageActive;
        }
        else
        {
            imageComponent.sprite = imageInactive;
        }
    }
}
