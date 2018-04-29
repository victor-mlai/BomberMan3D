using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPickUp : MonoBehaviour {
    public float pickUpDuration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider player)
    {
        // create little explosion on pickup??? idk

        // disable mesh render and collisions
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;

        // apply behaviour on player
        player.GetComponent<PlayerBomb>().bombRange += 2.0f;

        // wait for pickUpDuration seconds
        yield return new WaitForSeconds(pickUpDuration);

        // undo effect
        player.GetComponent<PlayerBomb>().bombRange -= 2.0f;

        // destroy pickup item
        Destroy(gameObject);
    }
}
