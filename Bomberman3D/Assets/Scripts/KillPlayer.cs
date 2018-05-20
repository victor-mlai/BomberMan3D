using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour, IKillable {

    private GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager");
    }

    public void Kill()
    {
        GetComponent<PlayerMovement>().isInputDisabled = true;

        GameManager.GetComponent<GameManager>().GameFinished = true;
        GameManager.GetComponent<GameManager>().YouDiedUI.SetActive(true);

        // Make Camera 3rd Person

        // Play Dead Animation

    }
}
