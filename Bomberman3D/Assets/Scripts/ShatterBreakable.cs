using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShatterBreakable : NetworkBehaviour, IBreakable {

    public GameObject effect;
    
    public void Break()
    {
        Instantiate(effect, transform.position, transform.rotation);

        GetComponent<DropPowerUp>().DropRandomPowerUp();

        CmdDestroy();
    }

    [Command]
    public void CmdDestroy()
    {
        Network.Destroy(gameObject);
    }
}
