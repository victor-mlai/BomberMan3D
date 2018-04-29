using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPowerUp : MonoBehaviour {
    [Range(0.0f, 1.0f)]
    public float powerUpProbability;

    public GameObject[] powerUp;

    public void DropRandomPowerUp()
    {
        if (Random.value <= powerUpProbability)
        {
            // TODO pick a random powerUp

            // create the powerUp
            Instantiate(powerUp[0], gameObject.transform.position, powerUp[0].transform.rotation);
        }
    }
}
