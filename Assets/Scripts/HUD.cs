using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image healthBar;
    public Text scoreText;

    public GameObject pausePanel;
    public GameObject gameplayPanel;

    private void Start()
    {
        pausePanel.SetActive(false);
        gameplayPanel.SetActive(true);
    }

    public void UpdateHealthUI(float newHealth, float maxHealth)
    {
        healthBar.fillAmount = newHealth / maxHealth;
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString("000000");
    }

    public void OpenPause(bool open)
    {
        pausePanel.SetActive(open);
    }

    public void OpenGameplay(bool open)
    {
        gameplayPanel.SetActive(open);
    }
}
