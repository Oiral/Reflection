using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public PlayerMovement selectedMoveScript;
    public PlayerMovement otherMoveScript;

    public RotateBoard rotateScript;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (selectedMoveScript.MovePlayer(Direction.North))
            {
                //Debug.Log("Move Other Player");
                otherMoveScript.MovePlayer(Direction.North);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (selectedMoveScript.MovePlayer(Direction.South))
            {
                //Debug.Log("Move Other Player");
                otherMoveScript.MovePlayer(Direction.South);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (selectedMoveScript.MovePlayer(Direction.West))
            {
                //Debug.Log("Move Other Player");
                otherMoveScript.MovePlayer(Direction.West);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (selectedMoveScript.MovePlayer(Direction.East))
            {
                //Debug.Log("Move Other Player");
                otherMoveScript.MovePlayer(Direction.East);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotateScript.BeginRotation();
            Flip();
        }
    }
    void Flip()
    {
        PlayerMovement temp = selectedMoveScript;
        selectedMoveScript = otherMoveScript;
        otherMoveScript = temp;
    }
}
