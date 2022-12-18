using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class RandomWalkGenerator : MonoBehaviour
{
    [SerializeField]
    protected Vector2 startPos = Vector2Int.zero;
    [SerializeField]
    protected int iterations = 10;
    [SerializeField]
    int walkLength = 10;
    [SerializeField]
    public bool startRandom = true;
    [SerializeField]
    private TileMapVisualizer tileMapVisualizer;

    public void RunGeneration()
    {
        HashSet<Vector2> floorPositions = RunRandomWalk();
        tileMapVisualizer.Clear();
        tileMapVisualizer.PaintFloorTiles(floorPositions);
    }

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
