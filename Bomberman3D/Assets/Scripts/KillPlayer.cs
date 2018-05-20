using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class KillPlayer : NetworkBehaviour, IKillable {

    private GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager");
    }

    public void Kill()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        GetComponent<PlayerMovement>().isInputDisabled = true;

        GameManager.GetComponent<GameManager>().GameFinished = true;
        GameManager.GetComponent<GameManager>().YouDiedUI.SetActive(true);

        // Make Camera 3rd Person

        // Play Dead Animation

    }
}
