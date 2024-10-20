using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tupperware : MonoBehaviour
{
    public int score = 0;
    public int maxScore = 9;

    public TMPro.TextMeshProUGUI scoreText;

    public AudioSource collectSound;

    private GameObject specialFull;
    private Image specialFullImage;
    private GameObject[] tupperwareBars;
    private List<BarState> tupperwareBarStates;
    private List<Image> tupperwareBarImages;


    // Blink
    private bool isBlinking = false;
    private float blinkDuration = 0.1f;

    void Awake()
    {
        tupperwareBarStates = new List<BarState>();
        tupperwareBarImages = new List<Image>();

        specialFull = GameObject.Find("SpecialFull");
        specialFullImage = specialFull.GetComponent<Image>();

        tupperwareBars = GameObject.FindGameObjectsWithTag("TupperwareBar");

        System.Array.Sort(tupperwareBars, (x, y) => x.name.CompareTo(y.name));
        for (int i = 0; i < (int)maxScore; i++)
        {
            tupperwareBarStates.Add(tupperwareBars[i].GetComponent<BarState>());
            tupperwareBarImages.Add(tupperwareBars[i].GetComponent<Image>());
        }
    }

    void Start()
    {
        scoreText.text = "0";
        score = 0;
        UpdateTupperwareBar();
    }

    void Update()
    {
        scoreText.text = score.ToString();

        if (Input.GetKeyDown(KeyCode.L))
        {
            ScoreTupperware();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            LoseScoreTupperware(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tupperware")){
            ScoreTupperware();
            Destroy(collision.gameObject);
        }
    }

    public void ScoreTupperware() {

        collectSound.Play();
        if (score == maxScore) return;

        score++;
        scoreText.text = score.ToString();
        
        UpdateTupperwareBar();
    }

    public void LoseScoreTupperware(int quantity)
    {
        if (score == 0) return;

        score -= quantity;
        scoreText.text = score.ToString();
        UpdateTupperwareBar();
    }

    public void UpdateTupperwareBar()
    {
        for (int i = 0; i < (int)maxScore; i++)
        {
            BarState tupperwareBarState = tupperwareBarStates[i];
            tupperwareBars[i].SetActive(score < 9);

            if (tupperwareBarState != null)
            {
                if (i < score)
                {
                    tupperwareBarState.Active();
                }
                else
                {
                    tupperwareBarState.Inactive();
                }
            }
        }

        if (score == 9 && !isBlinking)
        {
            specialFull.SetActive(true);
            StartCoroutine(BlinkTupperwareBars());
        }else {
            specialFull.SetActive(false);
        }
    }

    public IEnumerator BlinkTupperwareBars()
    {
        isBlinking = true;

        while (score == maxScore)
        {
            Color tempColor = specialFullImage.color;
            tempColor.a = 0.85f;
            specialFullImage.color = tempColor;

            yield return new WaitForSeconds(blinkDuration);

            tempColor.a = 1f;
            specialFullImage.color = tempColor;

            yield return new WaitForSeconds(blinkDuration);
        }

        isBlinking = false;
    }

}
