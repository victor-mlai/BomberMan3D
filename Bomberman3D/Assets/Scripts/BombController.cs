using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {
    public int bombRange;

    // SerializeField means that Unity will create a Field in the interface so you can modify the attribute
    // click on Bomb prefab and you will see the field under "BombController" Component
    [SerializeField]
    private float explosionDelay;

    private BoxCollider bc;

    // Use this for initialization
    void Start () {
        bc = GetComponent<BoxCollider>();
        bc.isTrigger = true;

        // in explosionDelay seconds, the Explode function will be called
        Invoke("Explode", explosionDelay);
    }

    private void OnTriggerExit(Collider other)
    {
        // if the Player exits the Trigger, the Trigger becomes a Collider
        if (other.gameObject.tag.Equals("Player"))
            bc.isTrigger = false;
    }

    void Explode()
    {
        // built in function .. simillar to free(x);
        Destroy(gameObject);
    }
}
