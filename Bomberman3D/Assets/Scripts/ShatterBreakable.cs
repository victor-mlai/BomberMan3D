using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterBreakable : MonoBehaviour, IBreakable {

    public GameObject effect;

    public void Break()
    {
        Instantiate(effect, transform.position, transform.rotation);

        GetComponent<DropPowerUp>().DropRandomPowerUp();

        Destroy(gameObject);
    }
}
