using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour {

	public int currentLevel = 0;

    public static LevelManagerScript instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void NextLevel()
    {
        Debug.Log("Scene loading");
        SceneManager.LoadScene(currentLevel += 1);
    }
}
