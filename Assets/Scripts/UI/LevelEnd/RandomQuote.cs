using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class RandomQuote : MonoBehaviour
{
    public TextMeshProUGUI quoteText;
    public List<string> quotes = new List<string>();

    void Start()
    {
        quoteText = GetComponent<TextMeshProUGUI>();

        int randomIndex = Random.Range(0, quotes.Count);
        string randomQuote = quotes[randomIndex];
        
        quoteText.text = randomQuote;
    }
}
