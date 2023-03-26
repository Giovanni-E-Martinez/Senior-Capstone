using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to detect players.
/// </summary>
public class TargetDetector : Detector
{
    [SerializeField]
    private float targetDetectionRange = 5;
    [SerializeField]
    private LayerMask obstaclesLayerMask, playerLayerMask;
    [SerializeField]
    private bool showGizmos = false;

    // Gizmo parameters
    private List<Transform> colliders;

    /// <summary>
    /// Override of Detect method from inherited class.
    /// </summary>
    /// <param name="aiData"></param>
    public override void Detect(AIData aiData)
    {
        // Find out if player is near
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, targetDetectionRange, playerLayerMask);

        if(playerCollider != null)
        {
            // Check if player can be seen
            Vector2 direction = (playerCollider.transform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, targetDetectionRange, obstaclesLayerMask);

            // Make sure that the collider seen is on the "Player" layer
            if(hit.collider != null && (playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0)
            {
                Debug.DrawRay(transform.position, direction * targetDetectionRange, Color.magenta);
                colliders = new List<Transform>() { playerCollider.transform };
            }
            else
            {
                colliders = null;
            }
        }
        else
        {
            // Enemy cannot see player
            colliders = null;
        }
        aiData.targets = colliders;
    }

    /// <summary>
    /// Method used to visualize detections.
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if(showGizmos == false)
            return;

        Gizmos.DrawWireSphere(transform.position, targetDetectionRange);
        
        if(colliders == null)
            return;
        Gizmos.color = Color.magenta;
        foreach(var item in colliders)
        {
            Gizmos.DrawSphere(item.position, 0.3f);
        }
    }
}
