using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateBoard : MonoBehaviour {

    public Button rotateButton;
    public float waitTime = 1;
    [Range(10, 50)]
    public float framesOfRotation = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BeginRotation()
    {
        print("StartedRotation");
        StartCoroutine(StartBoardRotation());
       // StartCoroutine(LockOutRotationButton());
    }

    IEnumerator StartBoardRotation()
    {
        yield return new WaitForSeconds(waitTime);
        float rotationValue = 180 / framesOfRotation;
        float accumulatedRotation = 0;
        for (int i = 0; i < framesOfRotation - 1; i++)
        {
            print("Rotating");
            transform.Rotate(rotationValue, 0, 0);
            accumulatedRotation += rotationValue;
            yield return new WaitForEndOfFrame();
        }
        transform.Rotate(180 - accumulatedRotation, 0, 0);
        yield return new WaitForEndOfFrame();
        print("End rotation");
    }

    IEnumerator LockOutRotationButton()
    {
        yield return new WaitForSeconds(0.1f);
        rotateButton.interactable = false;
        yield return new WaitForSeconds(1.5f);
        rotateButton.interactable = true;
    }
}
