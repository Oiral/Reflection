﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public PlayerMovement selectedMoveScript;
    public PlayerMovement otherMoveScript;

    public RotateBoard rotateScript;

    // Update is called once per frame
    void Update () {
		if (Input.GetButtonDown("Up"))
		{
			if (selectedMoveScript.MovePlayer(Direction.North,true))
			{
				//Debug.Log("Move Other Player");
				otherMoveScript.MovePlayer(Direction.North, false);
			}
		}
		if (Input.GetButtonDown("Down"))
        {
            if (selectedMoveScript.MovePlayer(Direction.South, true))
            {
                //Debug.Log("Move Other Player");
                otherMoveScript.MovePlayer(Direction.South, false);
            }
        }
		if (Input.GetButtonDown("Left"))
        {
            if (selectedMoveScript.MovePlayer(Direction.West, true))
            {
                //Debug.Log("Move Other Player");
                otherMoveScript.MovePlayer(Direction.West, false);
            }
        }
		if (Input.GetButtonDown("Right"))
        {
            if (selectedMoveScript.MovePlayer(Direction.East, true))
            {
                //Debug.Log("Move Other Player");
                otherMoveScript.MovePlayer(Direction.East, false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotateScript.BeginRotation();
            //FlipSelected();
        }
    }
    void FlipSelected()
    {
        PlayerMovement temp = selectedMoveScript;
        selectedMoveScript = otherMoveScript;
        otherMoveScript = temp;
    }
}
