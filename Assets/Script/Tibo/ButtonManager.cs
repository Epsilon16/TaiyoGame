using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Panel;

    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnterAnim()
    {
        GetComponent<Animation>().Play("Button_Pressed");
    }

    public void ExitAnim()
    {
        GetComponent<Animation>().Stop("Button_Pressed");
    }

    public void ReturnToGame()
    {
        Player.SetActive(true);
        Panel.SetActive(false);
        Cursor.visible = false;
    }

    public void retuntoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
}
