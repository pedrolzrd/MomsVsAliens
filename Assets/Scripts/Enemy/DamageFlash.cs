using System.Collections;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [ColorUsage(true, true)]
    [SerializeField] private Color _flashColor = Color.white;
    [SerializeField] private float flashTime = 0.25f;
    [SerializeField] private AnimationCurve _flashSpeedCurve;
    private SpriteRenderer sr;
    private Material material;

    private Coroutine _damageFlashCoroutine;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        Init();
    }

    private void Init()
    {
        material = sr.material;
    }

    public void CallDamageFlash()
    {
        _damageFlashCoroutine = StartCoroutine(DamageFlasher());
    }

    private IEnumerator DamageFlasher()
    {
        // Set te Color
        SetFlashColor();

        //Lerp the Flash Amount
        float currentFlashAmount = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < flashTime)
        {
            //iterate elapsedTime
            elapsedTime += Time.deltaTime;

            //lerp the flash amount
            currentFlashAmount = Mathf.Lerp(1f, _flashSpeedCurve.Evaluate(elapsedTime), (elapsedTime/flashTime));
            SetFlashAmount(currentFlashAmount);

            yield return null;
        }
    }

    private void SetFlashColor()
    {
        //Set The Color 

        material.SetColor("_FlashColor", _flashColor);
    }

    private void SetFlashAmount(float amount)
    {
        //set the flash amount
        material.SetFloat("_FlashAmount", amount);
    }
}
