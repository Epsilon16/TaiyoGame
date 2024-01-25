using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int CurrentScore { get; set; }
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Image _gameOverPanel;
    [SerializeField] private float _fadeTime = 2f;

    public float TimeTillGameOver = 1.5f;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Panel;

    [SerializeField] private GameObject Panel2;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += FadeGame;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= FadeGame;
    }

    private void Update()
    {
        if (UserInput.isPausePressed)
        {
            Player.SetActive(false);
            Panel.SetActive(true);
            Cursor.visible = true;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _scoreText.text = CurrentScore.ToString("0");

        Cursor.visible = false;
    }

    public void IncreaseScore (int amount)
    {
        CurrentScore += amount;
        _scoreText.text = CurrentScore.ToString("0");
    }

    public void GameOver()
    {
        StartCoroutine(ResetGame());
    }

    private IEnumerator ResetGame()
    {
        _gameOverPanel.gameObject.SetActive(true);

        Color startColor = _gameOverPanel.color;
        startColor.a = 0f;
        _gameOverPanel.color = startColor;

        float elapsedTime = 0f;
        while(elapsedTime < _fadeTime)
        {
            elapsedTime += Time.deltaTime;

            float newAlpha = Mathf.Lerp(0f, 1f, (elapsedTime / _fadeTime));
            startColor.a = newAlpha;
            _gameOverPanel.color = startColor;

            yield return null;
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = true;
        //SceneManager.LoadScene(0);
        StartCoroutine(GameOverMenu());
    }

    private IEnumerator GameOverMenu()
    {
        yield return new WaitForSeconds(0.1f);
        Player.SetActive(false);
        Panel2.SetActive(true);
    }

    private void FadeGame(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeGameIn());
    }

    private IEnumerator FadeGameIn()
    {
        _gameOverPanel.gameObject.SetActive(true);
        Color startColor = _gameOverPanel.color;
        startColor.a = 1f;
        _gameOverPanel.color = startColor;

        float elapsedTime = 0f;
        while (elapsedTime < _fadeTime)
        {
            elapsedTime += Time.deltaTime;

            float newAlpha = Mathf.Lerp(1f, 0f, (elapsedTime / _fadeTime));
            startColor.a = newAlpha;
            _gameOverPanel.color = startColor;

            yield return null;
        }

        _gameOverPanel.gameObject.SetActive(false);
    }
}
