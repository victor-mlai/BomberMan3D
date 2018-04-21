using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBomb : NetworkBehaviour {

    public GameObject bombPrefab;
    public float bombRange;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdDropBomb();
        }

    }

    [Command]
    void CmdDropBomb()
    {
        // don't mind the position formula ...
        Vector3 position = new Vector3(
            (Mathf.Floor((gameObject.transform.position.x) / 2) + Mathf.Ceil((gameObject.transform.position.x) / 2)),
            GetComponent<CapsuleCollider>().height / 2,
            (Mathf.Floor((gameObject.transform.position.z) / 2) + Mathf.Ceil((gameObject.transform.position.z) / 2))
            );

        // Creates a bomb object at the specified position with no rotation
        GameObject newBomb = Instantiate(bombPrefab, position, Quaternion.identity);

        // Set bombs' range
        newBomb.GetComponent<BombController>().SetBombRange(bombRange);

        // Spawn the bomb on the Clients
        NetworkServer.Spawn(newBomb);
    }
}
