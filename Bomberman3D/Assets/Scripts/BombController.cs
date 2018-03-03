using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {
    public int bombRange;

    [SerializeField]
    private float explosionDelay;

    // Use this for initialization
    void Start () {
        Invoke("Explode", explosionDelay);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void Explode()
    {
        Destroy(gameObject);
    }
}
