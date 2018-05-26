using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPowerUp : MonoBehaviour {
    [Range(0.0f, 1.0f)]
    public float powerUpProbability;

    public GameObject[] powerUps;

    public void DropRandomPowerUp()
    {
        if (Random.value <= powerUpProbability)
        {
            // pick a random powerUp
            int rand_index = Random.Range(0, powerUps.Length);

            // create the powerUp
            Instantiate(powerUps[rand_index], gameObject.transform.position, powerUps[rand_index].transform.rotation);
        }
    }
}
