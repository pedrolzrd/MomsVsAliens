using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlickerEffect : MonoBehaviour
{
    private Image neonImage;
    public float minAlpha = 0.3f;
    public float maxAlpha = 1f;  
    public float flickerSpeedMin = 0.5f;
    public float flickerSpeedMax = 0.1f;

    private void Awake()
    {
        neonImage = GetComponent<Image>();
    }

    private void Start()
    {
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            float randomAlpha = Random.Range(minAlpha, maxAlpha);
  
            Color newColor = neonImage.color;
            newColor.a = randomAlpha;
            neonImage.color = newColor;
           
            yield return new WaitForSeconds(Random.Range(flickerSpeedMin, flickerSpeedMax));
        }
    }
}