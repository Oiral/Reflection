using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour {

	public bool mainMenu = true;
	public bool pauseMenu = false;
	public bool winMenu = false;

	public GameObject mainMenuPanel;
	public GameObject pauseMenuPanel;
	public GameObject winMenuPanel;

	public static UIScript instance;

	void Awake(){
		if (instance == null){
			instance = this;
		}else if (instance != this){
			Destroy(gameObject);
		}
		UpdateMenuUI ();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			Debug.Log ("Pause");
			mainMenu = false;
			pauseMenu = !pauseMenu;

			UpdateMenuUI();
		}
	}

	public void UpdateMenuUI(){
		mainMenuPanel.SetActive (mainMenu);
		pauseMenuPanel.SetActive (pauseMenu);
		//winMenuPanel.SetActive (winMenu);
	}


}
