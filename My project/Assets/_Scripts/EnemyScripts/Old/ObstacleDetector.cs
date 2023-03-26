using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to detect obstacles.
/// </summary>
public class ObstacleDetector : Detector
{
    [SerializeField]
    private float detectionRadius = 2;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private bool showGizmos = true;

    Collider2D[] colliders;

    /// <summary>
    /// Override of Detect method provided from inherited class.
    /// </summary>
    /// <param name="aiData">Provided data.</param>
    public override void Detect(AIData aiData)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, layerMask);
        aiData.obstacles = colliders;
    }

    /// <summary>
    /// Method used to visualize detections.
    /// </summary>
    private void OnDrawGizmos()
    {
        if(showGizmos == false)
            return;
        if(Application.isPlaying && colliders != null)
        {
            Gizmos.color = Color.red;
            foreach(Collider2D obstacleCollider in colliders)
            {
                Gizmos.DrawSphere(obstacleCollider.transform.position, 0.2f);
            }
        }
    }
}
