using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCameraController : MonoBehaviour {
    public GameObject backgroundCamera;
    public GameObject backgroundCameraShell;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject mCam = GameObject.Find("Main Camera");
        GameObject shell = mCam.GetComponentInParent<Transform>().gameObject;
        backgroundCamera.transform.SetPositionAndRotation(mCam.transform.position, mCam.transform.rotation);
        backgroundCameraShell.transform.SetPositionAndRotation(shell.transform.position, shell.transform.rotation);
	}
}
