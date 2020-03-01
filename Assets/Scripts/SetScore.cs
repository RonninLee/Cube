using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    public Text bestText;

    void Start()
    {
        int score = 0;
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }

        int best = 0;
        if (PlayerPrefs.HasKey("Best"))
        {
            best = PlayerPrefs.GetInt("Best");
        }

        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("Best", best);
        }
        bestText.text = best.ToString("000000");
    }
}
