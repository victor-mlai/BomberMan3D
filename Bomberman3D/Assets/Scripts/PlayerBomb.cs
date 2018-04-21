using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour {

    public GameObject bombPrefab;
    public float bombRange;

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
        // TODO: DropBomb only if there is no bomb here already

        // don't mind the position formula ...
        Vector3 position = new Vector3(
            (Mathf.Floor((gameObject.transform.position.x) / 2) + Mathf.Ceil((gameObject.transform.position.x) / 2)),
            GetComponent<CapsuleCollider>().height / 2,
            (Mathf.Floor((gameObject.transform.position.z) / 2) + Mathf.Ceil((gameObject.transform.position.z) / 2))
            );

        // TODO: if position is inside a collider => don't create the bomb
        //if (Physics.CheckSphere(position, 0.001f, LayerMask.NameToLayer("Bomb")))
        //    return;

        // Creates a bomb object at the specified position with no rotation
        GameObject newBomb = Instantiate(bombPrefab, position, Quaternion.identity);

        // Set bombs' range
        newBomb.GetComponent<BombController>().SetBombRange(bombRange);
    }
}
