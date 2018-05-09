using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateBoard : MonoBehaviour {

    public Vector3 targetPos = new Vector3(0,0,0);

    public Button rotateButton;
    public float waitTime = 1;
    [Range(10, 50)]
    public float framesOfRotation = 10;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
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
            //transform.Rotate(new Vector3(1, 0, 1), rotationValue);
            accumulatedRotation += rotationValue;
            yield return new WaitForEndOfFrame();
        }

        transform.Rotate(180 - accumulatedRotation, 0, 0);
        //transform.Rotate(new Vector3(1, 0, 1), 180 - accumulatedRotation);

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

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
    }
}
