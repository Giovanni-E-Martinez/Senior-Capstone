using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to allow enemy AI to detect player.
/// </summary>
public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private List<Detector> detectors;
    [SerializeField]
    private AIData aiData;
    [SerializeField]
    private float detectionDelay = 0.05f;

    // Called before first frame.
    private void Start()
    {
        // Detect player and obstacles around
        InvokeRepeating("PerformDetection", 0, detectionDelay);
    }

    /// <summary>
    /// Iterate through detectors to perform detections.
    /// </summary>
    private void PerformDetection()
    {
        foreach(Detector detector in detectors)
        {
            detector.Detect(aiData);
        }
    }
}
