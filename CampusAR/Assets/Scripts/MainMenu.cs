using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayMenu ()
    {
        SceneManager.LoadScene(0);
    }
    //play the navigatyion game without the obstacles
    public void PlaySafe ()
    {
        SceneManager.LoadScene(1);
    }

    //play the game with the obstacles
    public void PlayBlocked ()
    {
        SceneManager.LoadScene(2);
    }

    // to quit the game from main menu
    public void QuitGame()
    {
        Debug.Log("QUIT!\n");
        Application.Quit();
    }
}
