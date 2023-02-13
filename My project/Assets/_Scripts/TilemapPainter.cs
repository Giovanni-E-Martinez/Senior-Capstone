using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Script used to paint tiles onto the tilemap using provided positions from a hashset.
/// </summary>
public class TilemapPainter : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap;
    [SerializeField]
    private TileBase floorTile, wallTile;

    /// <summary>
    /// Paint entire floor on provided hashset values.
    /// </summary>
    /// <param name="floor">Defined floor hashset.</param>
    public void PaintFloor(IEnumerable<Vector2Int> floor)
    {
        PaintFloorTiles(floor, floorTilemap, floorTile);
    }

    /// <summary>
    /// Paint walls on provided hashset values.
    /// </summary>
    /// <param name="walls">Defined walls hashset.</param>
    public void PaintWalls(IEnumerable<Vector2Int> walls)
    {
        PaintWallTiles(walls, wallTilemap, wallTile);
    }

    /// <summary>
    /// Method to paint floor tiles onto individual tile positions.
    /// </summary>
    /// <param name="floor">Defined floor hashset.</param>
    /// <param name="floorTilemap">Defined floor tilemap.</param>
    /// <param name="floorTile">Defined floor tile.</param>
    private void PaintFloorTiles(IEnumerable<Vector2Int> floor, Tilemap floorTilemap, TileBase floorTile)
    {
        foreach (var position in floor)
        {
            var tilePosition = floorTilemap.WorldToCell((Vector3Int)position);
            floorTilemap.SetTile(tilePosition, floorTile);
        }
    }

    /// <summary>
    /// Method to paint wall tiles onto individual tile positions.
    /// </summary>
    /// <param name="walls"></param>
    /// <param name="wallTilemap"></param>
    /// <param name="wallTile"></param>
    private void PaintWallTiles(IEnumerable<Vector2Int> walls, Tilemap wallTilemap, TileBase wallTile)
    {
        foreach (var position in walls)
        {
            var tilePosition = wallTilemap.WorldToCell((Vector3Int)position);
            wallTilemap.SetTile(tilePosition, wallTile);
        }
    }
}
