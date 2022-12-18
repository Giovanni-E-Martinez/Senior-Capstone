using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

/// <summary>
/// Class respondible for implementing and running the RandomWalk algorithm of the ProceduralGeneration scrip and the TileMapVisualizer.
/// </summary>
public class RandomWalkGenerator : MonoBehaviour
{
    /// <summary>
    /// Starting position of the generator.
    /// </summary>
    [SerializeField]
    protected Vector2 startPos = Vector2Int.zero;
    /// <summary>
    /// Iterations that the generator will run.
    /// </summary>
    [SerializeField]
    protected int iterations = 10;
    /// <summary>
    /// Number of units that the generator will travel.
    /// </summary>
    [SerializeField]
    int walkLength = 10;
    /// <summary>
    /// Determines wether the generator will start at random points (true) or at the origin (false).
    /// </summary>
    [SerializeField]
    public bool startRandom = true;
    /// <summary>
    /// Instance of the TileMapVisualizer class.
    /// </summary>
    [SerializeField]
    private TileMapVisualizer tileMapVisualizer;

    /// <summary>
    /// Runs the RandomWalk algorithm and applies the assets to the tile-map.
    /// </summary>
    public void RunGeneration()
    {
        HashSet<Vector2> floorPositions = RunRandomWalk();
        tileMapVisualizer.Clear();
        tileMapVisualizer.PaintFloorTiles(floorPositions);
    }

    /// <summary>
    /// Method that uses the RandomWalk aglorithm and creates a path to generate the map.
    /// </summary>
    /// <returns>Returns the generated path.</returns>
    protected HashSet<Vector2> RunRandomWalk()
    {
        var currentPosition = startPos;
        HashSet<Vector2> floorPositions = new HashSet<Vector2>();
        for (int i = 0; i < iterations; i++)
        {
            var path = ProceduralGenerationAlgorithm.RandomWalk(currentPosition, walkLength);
            floorPositions.UnionWith(path);
            if (startRandom)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }

        return floorPositions;
    }
}
