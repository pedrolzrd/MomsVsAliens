using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterSelector : MonoBehaviour
{
    private Image background;
    public Sprite bgNormal;
    public Sprite bgHover;
    public Sprite bgSelected;

    private bool isSelected = false;

    public void Awake() {
        background = GetComponent<Image>();
    }

    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     HoverInCharacter();
    // }

    // public void OnPointerExit(PointerEventData eventData)
    // {
    //     HoverOutCharacter();
    // }

    public void HoverInCharacter()
    {
        if (!isSelected)
        {
            background.sprite = bgHover;
        }
    }

    public void HoverOutCharacter()
    {
        if (!isSelected)
        {
            background.sprite = bgNormal;
        }
    }

    public void SelectCharacter()
    {
        StartCoroutine(Blink());
        background.sprite = bgSelected;
    }

    public IEnumerator Blink()
    {
        float blinkDuration = 0.05f;

        float i = 0;
        while (i <= 15)
        {

            Color tempIconColor = background.color;
            tempIconColor.a = 0.66f;
            background.color = tempIconColor;

            yield return new WaitForSeconds(blinkDuration * i);

            tempIconColor.a = 1f;
            background.color = tempIconColor;

            yield return new WaitForSeconds(blinkDuration * i);

            i += 0.5f;
        }
    }
}
