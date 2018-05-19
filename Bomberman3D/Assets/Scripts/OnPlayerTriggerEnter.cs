using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerTriggerEnter : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        // if the Player enters the Trigger
        if (other.gameObject.tag.Equals("Player"))
        {
            other.transform.GetComponent<PlayerMovement>().DisableInput();

            // TODO: pause game

            // TODO: show canvas with Level Cleared
        }
    }
}
