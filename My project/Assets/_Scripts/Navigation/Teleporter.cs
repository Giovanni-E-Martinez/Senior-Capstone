using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GateCrash
{
    public class Teleporter : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Teleporting!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
