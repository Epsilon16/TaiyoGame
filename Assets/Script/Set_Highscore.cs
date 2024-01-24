using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Set_Highscore : MonoBehaviour
{
    private int highscore;

    

    [SerializeField] private TextMeshProUGUI HighScoreText;

    private void Awake()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        HighScoreText.text = highscore.ToString();
    }

    private void Update()
    {
        if (GameManager.instance.CurrentScore >= highscore)
        {
            highscore = GameManager.instance.CurrentScore;
            PlayerPrefs.SetInt("Highscore", GameManager.instance.CurrentScore);
            HighScoreText.text = highscore.ToString();
        }
    }


}
