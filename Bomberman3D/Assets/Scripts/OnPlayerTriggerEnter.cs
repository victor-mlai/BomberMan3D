using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerTriggerEnter : MonoBehaviour {

    private GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the Player enters the Trigger
        if (other.gameObject.tag.Equals("Player"))
        {
            other.transform.GetComponent<PlayerMovement>().isInputDisabled = true;

            // show canvas with Level Cleared
            GameManager.GetComponent<GameManager>().LevelCompletedUI.SetActive(true);
            GameManager.GetComponent<GameManager>().GameFinished = true;
        }
    }
}
