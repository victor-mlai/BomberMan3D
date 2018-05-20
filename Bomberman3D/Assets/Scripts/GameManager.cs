using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject LevelCompletedUI;
    public GameObject YouDiedUI;

    [HideInInspector]
    public bool GameFinished = false;

    public string NextLevelName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (GameFinished)
                SceneManager.LoadScene(NextLevelName);
        }
    }
}
