using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private Player player;
        private bool isPaused;
    
        public GameObject PausePanel;

        // Update is called once per frame
        public void Update()
        {
            if(player.InputHandler.Paused)
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

        public void Pause() 
        {
            Debug.Log("Paused");
            player.InputHandler.Paused = true;
        }

        public void Continue()
        {
            Debug.Log("Unpaused");
            player.InputHandler.Paused = false;
        }

        public void ExitMatch()
        {
            Debug.Log("Quiting scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
