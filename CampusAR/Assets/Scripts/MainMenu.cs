using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //play the navigatyion game without the obstacles
    public void PlaySafe ()
    {
        SceneManager.LoadScene(1);
    }
    
    //play the game with the obstacles


    // to quit the game from main menu
    public void QuitGame()
    {
        Debug.Log("QUIT!\n");
        Application.Quit();
    }
}
