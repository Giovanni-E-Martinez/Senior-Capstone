using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Script to control random dungeon generation behavior.
/// </summary>
public class DungeonGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int maxRoutes = 20;
    [SerializeField]
    private int roomRadius = 4;
    [SerializeField]
    private int deviation = 1;
    [SerializeField]
    private TilemapPainter tilemapPainter;
    private List<HashSet<Vector2Int>> enemyRooms = new List<HashSet<Vector2Int>>();
    private int routeCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        // Create and initialize a unified floor hashset.
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        // Create and initialize a list of room centers.
        List<Vector2Int> roomCenters = new List<Vector2Int>();
        int x = 0;
        int y = 0;
        // Generate a starting room for the player and add room data to floor hashset.
        floor.UnionWith(GenerateChunk(x, y, roomRadius));
        // Add the center of the generated room to the roomCenters list.
        roomCenters.Add(new Vector2Int(x, y));
        // Create a new room in a random direction from the previous x and y positions.
        NewRoute(x, y, floor, roomCenters);
        // Create and initialize a unified hashset for the room connections using the list of room centers as a guide.
        HashSet<Vector2Int> bridges = GenerateConnection(roomCenters);
        // Add the bridges hashset to the floor hashset.
        floor.UnionWith(bridges);

        // Paint the floor tiles over the floor hashset values.
        tilemapPainter.PaintFloor(floor);
        // Paint the walls around the floor hashset.
        tilemapPainter.PaintWalls(FillWalls(floor));
    }

    /// <summary>
    /// Method to add walls to a hashset for the tilemapPainter to use when creating the walls.
    /// </summary>
    /// <param name="floor">The unified floor hashset that is used to generate the wall boundaries.</param>
    /// <returns>Returns the hashset containing the values for the wall locations.</returns>
    private HashSet<Vector2Int> FillWalls(HashSet<Vector2Int> floor)
    {
        // Create and instantiate a hashset for the wall values.
        HashSet<Vector2Int> walls = new HashSet<Vector2Int>();
        // Loop through each floor position to find the tiles that need a wall.
        foreach (var pos in floor)
        {
            // Check every direction of a tile location for a neighbor.
            foreach (var direction in Directions2D.Directions())
            {
                // Add a wall location where there is a missing neighbor.
                var neighbor = pos + direction;
                if (floor.Contains(neighbor) == false)
                    walls.Add(neighbor);
            }

        }
        return walls;
    }

    /// <summary>
    /// Method to generate a new room or connector piece in a random direction.
    /// </summary>
    /// <param name="x">Current x position on the grid.</param>
    /// <param name="y">Current y position on the grid.</param>
    /// <param name="floor">Unified floor hashset to add rooms to.</param>
    /// <param name="roomCenters">List to contain the center value of each generated room.</param>
    private void NewRoute(int x, int y, HashSet<Vector2Int> floor, List<Vector2Int> roomCenters)
    {
        int leftCount = 0;
        int rightCount = 0;
        int upCount = 0;
        int downCount = 0;

        // Create an instantiate a Vector2 to contain the current room center.
        Vector2Int currentCenter = new Vector2Int();
        // Create an instantiate a hashset to contain the current room values.
        HashSet<Vector2Int> currentRoom = new HashSet<Vector2Int>();

        // Loop while max room count hasn't been reached.
        while (routeCount < maxRoutes)
        {
            // Generate a random value corresponding to a random direction.
            int direction = Random.Range(0, 4);

            // Go up
            if (direction == 0)
            {
                // Ensure that this direction has not been used for the value of deviation in a row
                if (upCount >= deviation)
                {
                    // Create a new room in another direction.
                    NewRoute(x, y, floor, roomCenters);
                }
                // Increase count of this direction being used in a row.
                upCount++;

                // Move up
                y += (roomRadius * 3 + 1);
                // Check if the position has been used.
                if (!floor.Contains(new Vector2Int(x, y)))
                {
                    // Determine whether to generate a room or a connector.
                    int roomOr = Random.Range(0, 3);
                    if (roomOr <= 1)
                    {
                        // Store currentCenter and currentRoom values.
                        currentCenter = new Vector2Int(x, y);
                        // Generate a room.
                        currentRoom = GenerateChunk(x, y, roomRadius);
                        floor.UnionWith(currentRoom);
                        // Add room to room count.
                        routeCount++;
                        // Add room center to list.
                        roomCenters.Add(currentCenter);
                        // Store room in list of enemyRooms for use when generating enemies.
                        enemyRooms.Add(currentRoom);
                    }
                    else
                    {
                        // Generate a connector
                        floor.UnionWith(GenerateConnector(x, y, 1));
                        roomCenters.Add(new Vector2Int(x, y));
                    }
                }
                // Create a new room in a new direction.
                NewRoute(x, y, floor, roomCenters);
            }

            // Go down
            else if (direction == 1)
            {
                // Ensure that this direction has not been used for the value of deviation in a row
                if (downCount >= deviation)
                {
                    // Create a new room in another direction.
                    NewRoute(x, y, floor, roomCenters);
                }
                // Increase count of this direction being used in a row.
                downCount++;

                // Move down
                y -= (roomRadius * 3 + 1);
                // Check if the position has been used.
                if (!floor.Contains(new Vector2Int(x, y)))
                {
                    // Determine whether to generate a room or a connector.
                    int roomOr = Random.Range(0, 3);
                    if (roomOr <= 1)
                    {
                        // Store currentCenter and currentRoom values.
                        currentCenter = new Vector2Int(x, y);
                        // Generate a room.
                        currentRoom = GenerateChunk(x, y, roomRadius);
                        floor.UnionWith(currentRoom);
                        // Add room to room count.
                        routeCount++;
                        // Add room center to list.
                        roomCenters.Add(currentCenter);

                        // Store room in list of enemyRooms for use when generating enemies.
                        enemyRooms.Add(currentRoom);
                    }
                    else
                    {
                        // Generate a connector
                        floor.UnionWith(GenerateConnector(x, y, 1));
                        roomCenters.Add(new Vector2Int(x, y));
                    }
                }
                // Create a new room in a new direction.
                NewRoute(x, y, floor, roomCenters);
            }

            // Go right
            else if (direction == 2)
            {
                // Ensure that this direction has not been used for the value of deviation in a row
                if (rightCount >= deviation)
                {
                    // Create a new room in another direction.
                    NewRoute(x, y, floor, roomCenters);
                }
                // Increase count of this direction being used in a row.
                rightCount++;

                // Move right
                x += (roomRadius * 5 + 1);
                // Check if the position has been used.
                if (!floor.Contains(new Vector2Int(x, y)))
                {
                    // Determine whether to generate a room or a connector.
                    int roomOr = Random.Range(0, 3);
                    if (roomOr <= 1)
                    {
                        // Store currentCenter and currentRoom values.
                        currentCenter = new Vector2Int(x, y);
                        // Generate a room.
                        currentRoom = GenerateChunk(x, y, roomRadius);
                        floor.UnionWith(currentRoom);
                        // Add room to room count.
                        routeCount++;
                        // Add room center to list.
                        roomCenters.Add(currentCenter);

                        // Store room in list of enemyRooms for use when generating enemies.
                        enemyRooms.Add(currentRoom);
                    }
                    else
                    {
                        // Generate a connector
                        floor.UnionWith(GenerateConnector(x, y, 1));
                        roomCenters.Add(new Vector2Int(x, y));
                    }
                }
                // Create a new room in a new direction.
                NewRoute(x, y, floor, roomCenters);
            }

            // Go left
            else if (direction == 3)
            {
                // Ensure that this direction has not been used for the value of deviation in a row
                if (leftCount >= deviation)
                {
                    // Create a new room in another direction.
                    NewRoute(x, y, floor, roomCenters);
                }
                // Increase count of this direction being used in a row.
                leftCount++;

                // Move left
                x -= (roomRadius * 5 + 1);
                // Check if the position has been used.
                if (!floor.Contains(new Vector2Int(x, y)))
                {
                    // Determine whether to generate a room or a connector.
                    int roomOr = Random.Range(0, 3);
                    if (roomOr <= 1)
                    {
                        // Store currentCenter and currentRoom values.
                        currentCenter = new Vector2Int(x, y);
                        // Generate a room.
                        currentRoom = GenerateChunk(x, y, roomRadius);
                        floor.UnionWith(currentRoom);
                        // Add room to room count.
                        routeCount++;
                        // Add room center to list.
                        roomCenters.Add(currentCenter);

                        // Store room in list of enemyRooms for use when generating enemies.
                        enemyRooms.Add(currentRoom);
                    }
                    else
                    {
                        // Generate a connector
                        floor.UnionWith(GenerateConnector(x, y, 1));
                        roomCenters.Add(new Vector2Int(x, y));
                    }
                }
                // Create a new room in a new direction.
                NewRoute(x, y, floor, roomCenters);
            }
        }
    }

    /// <summary>
    /// Method used to generate connector pieces.
    /// </summary>
    /// <param name="x">Current x position on grid.</param>
    /// <param name="y">Current y position on grid.</param>
    /// <param name="radius">Defined radius of connector room.</param>
    /// <returns>Returns hashset containing connector position values.</returns>
    private HashSet<Vector2Int> GenerateConnector(int x, int y, int radius)
    {
        // Create and instantiate a hashset to store connector room tiles.
        HashSet<Vector2Int> connector = new HashSet<Vector2Int>();
        // Loop through all tiles in x and y within radius.
        for (int mapX = x - radius; mapX <= x + radius; mapX++)
        {
            for (int mapY = y - radius; mapY <= y + radius; mapY++)
            {
                // Add position to hashset.
                Vector2Int tilePos = new Vector2Int(mapX, mapY);
                connector.Add(tilePos);
            }
        }
        return connector;
    }

    /// <summary>
    /// Method used to generate a room.
    /// </summary>
    /// <param name="x">Current x position on grid.</param>
    /// <param name="y">Current y position on grid.</param>
    /// <param name="radius">Defined radius of room.</param>
    /// <returns>Returns the hashset containing room position values.</returns>
    private HashSet<Vector2Int> GenerateChunk(int x, int y, int radius)
    {
        // Create and instantiate a hashset to store room tiles.
        HashSet<Vector2Int> chunk = new HashSet<Vector2Int>();
        // Loop through all tiles in x and y within radius.
        for (int mapX = x - (radius * 2); mapX <= x + (radius * 2); mapX++)
        {
            for (int mapY = y - radius; mapY <= y + radius; mapY++)
            {
                // Add position to hashset.
                Vector2Int tilePos = new Vector2Int(mapX, mapY);
                chunk.Add(tilePos);
            }
        }
        return chunk;
    }

    /// <summary>
    /// Method used to generate bridges between rooms and connectors.
    /// </summary>
    /// <param name="roomCenters">The list of stored room center positions.</param>
    /// <returns>Returns a hashset containing all values of bridge tile positions.</returns>
    private HashSet<Vector2Int> GenerateConnection(List<Vector2Int> roomCenters)
    {
        // Create and initialize a hashset to contain bridge tiles.
        HashSet<Vector2Int> connections = new HashSet<Vector2Int>();
        // Grab first room center as current.
        var currentRoomCenter = roomCenters[0];
        // Remove room center from list to prevent repeating.
        roomCenters.Remove(currentRoomCenter);
        // Loop through roomCenters list.
        while (roomCenters.Count > 0)
        {
            // Grab new first room center as next.
            Vector2Int nextRoomCenter = roomCenters[0];
            // Remove room center.
            roomCenters.Remove(nextRoomCenter);
            // Create and instantiate a temporary hashset to store positions between two centers.
            HashSet<Vector2Int> newBridge = GenerateBridge(currentRoomCenter, nextRoomCenter);
            Debug.Log("Current: " + currentRoomCenter.x + ", " + currentRoomCenter.y + " | Next: " + nextRoomCenter.x + ", " + nextRoomCenter.y);
            // Set next as current.
            currentRoomCenter = nextRoomCenter;
            // Add bridge to connections hashset.
            connections.UnionWith(newBridge);
        }
        return connections;
    }

    /// <summary>
    /// Method used to generate bridge individually.
    /// </summary>
    /// <param name="currentRoomCenter">Starting point.</param>
    /// <param name="nextRoomCenter">Ending point.</param>
    /// <returns>Returns hashset containing bridge positions.</returns>
    private HashSet<Vector2Int> GenerateBridge(Vector2Int currentRoomCenter, Vector2Int nextRoomCenter)
    {
        // Create and instantiate a hashset to contain bridge positions.
        HashSet<Vector2Int> bridge = new HashSet<Vector2Int>();
        var position = currentRoomCenter;
        // Add starting point.
        bridge.Add(position);
        // Loop through horizontal points until end point is reached.
        while (position.x != nextRoomCenter.x)
        {
            Debug.Log(position.x + " | " + nextRoomCenter.x);
            // Go right.
            if (position.x < nextRoomCenter.x)
            {
                position += Vector2Int.right;
            }
            // Go left
            else if (position.x > nextRoomCenter.x)
            {
                position += Vector2Int.left;
            }
            // Add positions to hashset.
            bridge.Add(position);
            bridge.Add(position + Vector2Int.up);
            bridge.Add(position + Vector2Int.down);
        }
        // Generate a connector to fill in gaps.
        bridge.UnionWith(GenerateConnector(position.x, position.y, 1));
        // Loop through vertical points until end point is reached.
        while (position.y != nextRoomCenter.y)
        {
            Debug.Log(position.y + " | " + nextRoomCenter.y);
            // Go up
            if (position.y < nextRoomCenter.y)
            {
                position += Vector2Int.up;
            }
            // Go down
            else if (position.y > nextRoomCenter.y)
            {
                position += Vector2Int.down;
            }
            // Add positions to hashset.
            bridge.Add(position);
            bridge.Add(position + Vector2Int.left);
            bridge.Add(position + Vector2Int.right);
        }
        // Generate a connector to fill in gaps.
        bridge.UnionWith(GenerateConnector(position.x, position.y, 1));
        return bridge;
    }

    /// <summary>
    /// Unimplemented method to create possible enemy spawn rooms.
    /// </summary>
    /// <returns>Returns possible enemy spawn room locations.</returns>
    private HashSet<Vector2Int> possibleEnemyRooms()
    {
        HashSet<Vector2Int> pER = new HashSet<Vector2Int>();
        foreach (var room in enemyRooms)
            pER.UnionWith(room);
        return pER;
    }
}

/// <summary>
/// Static class to define 8-point grid directions.
/// </summary>
public static class Directions2D
{
    public static List<Vector2Int> Directions()
    {
        List<Vector2Int> directions = new List<Vector2Int>();
        directions.Add(new Vector2Int(0, 1)); // North
        directions.Add(new Vector2Int(0, -1)); // South
        directions.Add(new Vector2Int(1, 0)); // East
        directions.Add(new Vector2Int(-1, 0)); // West
        directions.Add(new Vector2Int(1, 1)); // NorthEast
        directions.Add(new Vector2Int(1, -1)); // SouthEast
        directions.Add(new Vector2Int(-1, 1)); // NorthWest
        directions.Add(new Vector2Int(-1, -1)); // SouthWest

        return directions;
    }
}
