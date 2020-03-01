using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HUD hud { get; private set; }

    public bool isPaused;
    public bool isGameplay;

    private int score;
    private int best;

    private void Awake()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

        isPaused = false;
        isGameplay = true;

        score = 0;
        hud.SetScore(score);

        best = 0;
        if (PlayerPrefs.HasKey("Best"))
        {
            best = PlayerPrefs.GetInt("Best");
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            Pause();
        }
    }

    public void Pause()
    {
        isPaused = !isPaused;
        isGameplay = !isGameplay;

        hud.OpenPause(isPaused);
        hud.OpenGameplay(isGameplay);

        if(isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void AddScore(int add)
    {
        score += add;
        hud.SetScore(score);
    }
}
