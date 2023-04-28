using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class used to define the actions within the pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private bool isPaused;

    public GameObject PausePanel;

    // Update is called once per frame
    public void Update()
    {
        if (player.InputHandler.Paused)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// Sets the game to paused and opens the pause menu panel.
    /// </summary>
    public void Pause()
    {
        Debug.Log("Paused");
        player.InputHandler.Paused = true;
    }

    /// <summary>
    /// Sets the game to unpaused and closes the pause menu panel.
    /// </summary>
    public void Continue()
    {
        Debug.Log("Unpaused");
        player.InputHandler.Paused = false;
    }

    /// <summary>
    /// Quits the current scene and navigates to the previous scene in the build order.
    /// </summary>
    public void ExitMatch()
    {
        Debug.Log("Quiting scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
