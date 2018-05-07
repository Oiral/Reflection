using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { North, East, South, West };

public class PlayerMovement : MonoBehaviour {

    public GameObject targetTile;

    private void Update()
    {
        Vector3 targetPos = targetTile.transform.position;
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);

    }

    public bool MovePlayer(Direction dir)
    {
        foreach (GameObject tile in targetTile.GetComponent<TileConnectionsScript>().connections)
        {
            if (CheckDirection(targetTile.transform.position, tile.transform.position) == dir)
            {
                targetTile = tile;
                return true;
            }
            

        }
        return false;
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
