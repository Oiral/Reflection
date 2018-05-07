using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    public List<GameObject> connections;

    private void OnDrawGizmosSelected()
    {
        if (connections.Count > 0)
        {
            foreach (GameObject neighbor in connections)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(Average(transform.position, neighbor.transform.position), new Vector3(0.5f, 0.5f, 0.5f));
            }
        }
    }

    private Vector3 Average(Vector3 pos1, Vector3 pos2)
    {
        return (pos1 + pos2) / 2;
    }

}
