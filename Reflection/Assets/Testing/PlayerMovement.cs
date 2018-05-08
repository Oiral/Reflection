using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { North, East, South, West };

public class PlayerMovement : MonoBehaviour {

    public GameObject targetTile;
    GameObject startingTile;
    public float respawnTime = 1;
    public GameObject otherPlayer;

    private void Start()
    {
        startingTile = targetTile;
    }

    private void Update()
    {
        Vector3 targetPos = targetTile.transform.position;
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);

    }

    public bool MovePlayer(Direction dir,bool primary)
    {
        foreach (GameObject tile in targetTile.GetComponent<TileConnectionsScript>().connections)
        {
            if (CheckDirection(targetTile.transform.position, tile.transform.position) == dir)
            {
                switch (tile.GetComponentInParent<TileScript>().Type)
                {
                    case TileType.Default:
                        targetTile = tile;
                        return true;
                    case TileType.Hole:
                        StartCoroutine(Respawn());
                        targetTile = tile;
                        return true;
                    case TileType.Goal:
                        if (targetTile.gameObject.transform.parent == otherPlayer.GetComponent<PlayerMovement>().targetTile.gameObject.transform.parent && primary)
                        {
                            targetTile = tile;
                            LevelManagerScript.instance.NextLevel();
                            return true;
                        }else if (tile.gameObject.transform.parent == otherPlayer.GetComponent<PlayerMovement>().targetTile.gameObject.transform.parent && !primary)
                        {
                            targetTile = tile;
                            return true;
                        }
                        else
                            return false;
                    default:
                        return false;
                }
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

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        targetTile = startingTile;    
    }

}
