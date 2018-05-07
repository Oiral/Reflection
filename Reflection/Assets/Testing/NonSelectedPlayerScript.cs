using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonSelectedPlayerScript : MonoBehaviour {

    public GameObject TargetTile;

    private void Update()
    {
        Vector3 targetPos = TargetTile.transform.position;
        targetPos.y = -targetPos.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
    }
}
