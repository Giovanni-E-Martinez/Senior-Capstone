using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Class used to define the actions within the main menu.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Starts the game and navigates to the next scene in the build order.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Exits the application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
