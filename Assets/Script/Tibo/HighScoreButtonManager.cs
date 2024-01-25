using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreButtonManager : MonoBehaviour
{
    public GameObject HSButton;

    void Update()
    {
        if (PlayerPrefs.GetInt("Highscore") == 0)
        {
            HSButton.SetActive(false);
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
    }
}
