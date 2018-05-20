using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBomb : NetworkBehaviour
{

    public GameObject bombPrefab;
    public float bombRange;
    public int maxBombs;    // max number of bombs the player can drop

    private int bombCount = 0;
	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GetComponent<PlayerMovement>().isInputDisabled || PauseMenu.GameIsPaused)
                return;

            CmdDropBomb();
        }
    }

    [Command]
    void CmdDropBomb()
    {
        if (bombCount >= maxBombs)
            return;

        // don't mind the position formula ...
        Vector3 position = new Vector3(
            (Mathf.Floor((gameObject.transform.position.x) / 2) + Mathf.Ceil((gameObject.transform.position.x) / 2)),
            GetComponent<CapsuleCollider>().height / 2,
            (Mathf.Floor((gameObject.transform.position.z) / 2) + Mathf.Ceil((gameObject.transform.position.z) / 2))
            );

        // TODO: DropBomb only if there is no bomb here already
        // TODO: if position is inside a collider => don't create the bomb
        //if (Physics.CheckSphere(position, 0.001f, LayerMask.NameToLayer("Bomb")))
        //    return;

        // Creates a bomb object at the specified position with no rotation
        GameObject newBomb = Instantiate(bombPrefab, position, Quaternion.identity);

        // Set bombs' range
        newBomb.GetComponent<BombController>().SetBombRange(bombRange);

        bombCount++;
        Invoke("DecrementBombCount", newBomb.GetComponent<BombController>().GetExplosionDelay());

        NetworkServer.Spawn(newBomb);
    }

    void DecrementBombCount()
    {
        bombCount--;
    }
}
