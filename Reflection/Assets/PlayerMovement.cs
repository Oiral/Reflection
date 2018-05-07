using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { North, East, South, West };

public class PlayerMovement : MonoBehaviour {

    public GameObject targetTile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveTile(Direction.North);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveTile(Direction.South);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveTile(Direction.West);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveTile(Direction.East);
        }

        transform.position = Vector3.Lerp(transform.position, targetTile.transform.position, 0.1f);

    }

    void MoveTile(Direction dir)
    {
        foreach(GameObject tile in targetTile.GetComponent<TileScript>().connections)
        {
            if (CheckDirection(targetTile.transform.position,tile.transform.position) == dir)
            {
                targetTile = tile;
                break;
            }
        }
    }

    private Direction CheckDirection(Vector3 startingPos, Vector3 checkingPos)
    {
        if (startingPos.x < checkingPos.x)
        {
            return Direction.East;
        }else if (startingPos.x > checkingPos.x)
        {
            return Direction.West;
        }else if (startingPos.z < checkingPos.z)
        {
            return Direction.North;
        }
        else if (startingPos.z > checkingPos.z)
        {
            return Direction.South;
        }
        else
        {
            Debug.LogError("Can't find Direction - Defaulting to North");
            return Direction.North;
        } 
            
    }


}
