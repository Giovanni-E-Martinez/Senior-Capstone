using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgorithm
{
    public static HashSet<Vector2> RandomWalk(Vector2 startPos, int walkLength)
    {
        HashSet<Vector2> path = new HashSet<Vector2>();

        path.Add(startPos);
        var previousPos = startPos;

        for (int i = 0; i < walkLength; i++)
        {
            var pos = previousPos + Direction2D.getRandomDirection();
            path.Add(pos);
            previousPos = pos;
        }

        /*path.Add(new Vector2(1, 1));*/

        return path;
    }
}

public static class Direction2D
{
    public static List<Vector2> cardinalDirections = new List<Vector2>
    {
        new Vector2(0, .5f), // up
        new Vector2(.5f, 0), // right
        new Vector2(0, -.5f), // down
        new Vector2(-.5f, 0) // left
    };

    public static Vector2 getRandomDirection()
    {
        return cardinalDirections[Random.Range(0, cardinalDirections.Count)];
    }
}
