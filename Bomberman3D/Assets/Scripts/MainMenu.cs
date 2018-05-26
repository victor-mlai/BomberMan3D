using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainMenu : NetworkBehaviour {

    public string LevelName;

    public NetworkManager NetworkManager;

    public void Host()
    {
        //Start as host
        NetworkManager.StartHost();
        Connect();
    }

    public void Connect()
    {
        // TODO: Connect to server
        NetworkManager.StartClient();
        // Load Menu Level
        SceneManager.LoadScene(LevelName);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
