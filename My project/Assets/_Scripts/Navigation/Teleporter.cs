using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class used to define teleporter functionality.
/// </summary>
public class Teleporter : MonoBehaviour
{
    /// <summary>
    /// Navigates to the next scene in the build order after the player enters the object collider.
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Teleporting!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
