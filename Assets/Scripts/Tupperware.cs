using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tupperware : MonoBehaviour
{
    public int score = 0;

    public TMPro.TextMeshProUGUI scoreText;

    public AudioSource collectSound;

    void Start()
    {
        scoreText.text = "0";
        score = 0;
    }

    
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tupperware")){
            score++;
            scoreText.text = score.ToString();
            collectSound.Play();
            Destroy(collision.gameObject);
        }
    }
}
