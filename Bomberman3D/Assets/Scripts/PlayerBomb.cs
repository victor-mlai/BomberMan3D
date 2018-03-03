using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour {

    public GameObject bombPrefab;
    public int bombRange = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBomb();
        }

    }

    void DropBomb()
    {
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
        Vector3 position = new Vector3(
            (Mathf.Floor((gameObject.transform.position.x) / 2) + Mathf.Ceil((gameObject.transform.position.x) / 2)),
            //Mathf.RoundToInt(gameObject.transform.position.x),
            capsuleCollider.height / 2,
            (Mathf.Floor((gameObject.transform.position.z) / 2) + Mathf.Ceil((gameObject.transform.position.z) / 2))
            //Mathf.RoundToInt(gameObject.transform.position.z)
            );

        GameObject newBomb = Instantiate(bombPrefab, position, Quaternion.identity);
        newBomb.GetComponent<BombController>().bombRange = bombRange;
    }
}
