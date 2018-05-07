using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterBreakable : MonoBehaviour {

    public GameObject effect;

    public void Shatter()
    {
        Instantiate(effect, transform.position, transform.rotation);

        GetComponent<DropPowerUp>().DropRandomPowerUp();

        Destroy(gameObject);
    }
}
