using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// Basic camera controller that follows the player and zooms out if you hold CTRL.
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        private GameObject player;

        /// <summary>
        /// Called when initialized and active.
        /// </summary>
        public void Start()
        {
            
        }

        /// <summary>
        /// Called at the end of each frame.
        /// </summary>
        public void LateUpdate()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
            }

            if (player != null)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            }
        }
    }
