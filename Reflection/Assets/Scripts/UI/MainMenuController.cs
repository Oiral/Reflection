using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    
    public GameObject menu;
    public float scrollOffset;
    [Range(1,100)]
    public float animationTime;
    public AnimationCurve smoothing;
    int currentIndex = 0;
    int oldIndex;
    Vector3 originalMenuPosition;
    bool menuMoveable = true;

    // Use this for initialization
    void Start () {
        originalMenuPosition = menu.GetComponent<RectTransform>().localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            EvalInput(-1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            EvalInput(1);
        }
        print(currentIndex);
	}

    void MoveMenu()
    {
        Vector3 currentMenuPos = menu.GetComponent<RectTransform>().localPosition;
        Vector3 newMenuPos = originalMenuPosition + new Vector3(0, scrollOffset * currentIndex);
        menu.GetComponent<RectTransform>().localPosition = originalMenuPosition + new Vector3(0, scrollOffset * currentIndex);
        StartCoroutine(AnimateMenu(currentMenuPos, newMenuPos));
    }

    IEnumerator AnimateMenu(Vector3 oldPos, Vector3 newPos)
    {
        RectTransform menuTransform = menu.GetComponent<RectTransform>();
        int indexDifference = Mathf.Abs(currentIndex - oldIndex);
        for (int i = 0; i < animationTime; i++)
        {
            float t = smoothing.Evaluate(i * indexDifference / animationTime);
            menuTransform.localPosition = Vector3.Lerp(oldPos, newPos, t);
            if (t > 0.9)
            {
                menuMoveable = true;
            }
            yield return new WaitForEndOfFrame();
        }
        menuTransform.localPosition = newPos;

    }

    void ChangeIndex(int inc)
    {
        oldIndex = currentIndex;
        currentIndex = (currentIndex + inc + 3) % 3;
    }

    public void EvalInput(int incrementer)
    {
        if (menuMoveable)
        {
            menuMoveable = false;
            ChangeIndex(incrementer);
            MoveMenu();
        }
    }
}
