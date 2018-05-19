using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropExit : MonoBehaviour, IBreakable {
    public GameObject effect;
    public GameObject exit;
    public float exitHeightOffset;

    public void Break()
    {
        Instantiate(effect, transform.position, transform.rotation);

        Vector3 exitOffset = new Vector3(0, exitHeightOffset, 0);
        Instantiate(exit, transform.position - exitOffset, exit.transform.rotation);

        Destroy(gameObject);
    }
}
