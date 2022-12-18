using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class containing the script proper for generating the map.
/// </summary>
public static class ProceduralGenerationAlgorithm
{
    /// <summary>
    /// The method responsible for the RandomWalk algorithm.
    /// </summary>
    /// <param name="startPos">The starting position of the RandomWalk algorithm.</param>
    /// <param name="walkLength">The number of units a single RandomWalk iteration will travel.</param>
    /// <returns></returns>
    public static HashSet<Vector2> RandomWalk(Vector2 startPos, int walkLength)
    {
        // HashSet used to sstore the RandomWalk path information
        HashSet<Vector2> path = new HashSet<Vector2>();

        path.Add(startPos);
        var previousPos = startPos;

        // Randomly change direction each step
        for (int i = 0; i < walkLength; i++)
        {
            var pos = previousPos + Direction2D.getRandomDirection();
            path.Add(pos);
            previousPos = pos;
        }

        /*path.Add(new Vector2(1, 1));*/

        // Return the HashMap containing the path information.
        return path;
    }
}

/// <summary>
/// Static class used to store the different directions as Vector2 data.
/// </summary>
public static class Direction2D
{
    /// <summary>
    /// The four directions that the RandomWalk algorithm can travel.
    /// </summary>
    public static List<Vector2> cardinalDirections = new List<Vector2>
    {
        new Vector2(0, .5f), // up
        new Vector2(.5f, 0), // right
        new Vector2(0, -.5f), // down
        new Vector2(-.5f, 0) // left
    };

    /// <summary>
    /// Method used to retrieve a random direction for the cardianlDirections list.
    /// </summary>
    /// <returns>Returns the random direction corresponding to the random index number generated.</returns>
    public static Vector2 getRandomDirection()
    {
        return cardinalDirections[Random.Range(0, cardinalDirections.Count)];
    }
}
