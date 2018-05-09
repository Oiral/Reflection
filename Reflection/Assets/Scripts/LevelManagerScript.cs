using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour {

	public int currentLevel = 0;

    public static LevelManagerScript instance;

    public float waitTime = 0.7f;

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
        StartCoroutine(WaitForNextLevel());
    }

    IEnumerator WaitForNextLevel()
    {
        yield return new WaitForSeconds(waitTime/2);
        //FindBoard
        if (GameObject.FindGameObjectWithTag("Board") != null)
        {
            RotateBoard board = GameObject.FindGameObjectWithTag("Board").GetComponent<RotateBoard>();
            board.targetPos = new Vector3(0, -5, 0);
        }

        yield return new WaitForSeconds(waitTime / 2);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(currentLevel += 1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        //Reaches this point when its loaded
        //SceneManager.UnloadSceneAsync(currentLevel - 1);

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("<color=red>Quit Game</color>");
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
