using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCountScript : MonoBehaviour {
    public int maxCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    void PickUp(Collider player)
    {
        // create little explosion on pickup??? idk

        // increase player bombCount
        int maxBombs = player.GetComponent<PlayerBomb>().maxBombs;
        if (maxBombs < maxCount)
            player.GetComponent<PlayerBomb>().maxBombs++;

        // destroy pickup item
        Destroy(gameObject);
    }
}
