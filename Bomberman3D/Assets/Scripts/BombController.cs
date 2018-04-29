using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {
    // [HideInInspector] means that the attribute will be hidden in the Editor
    private float bombRange;
    public void SetBombRange(float newBombRange)
    {
        bombRange = newBombRange;
    }

    public ParticleSystem explosion;
    public GameObject fuseObject;

    // SerializeField means that Unity will create a Field in the Editor so you can modify the attribute
    // click on Bomb prefab and you will see the field under "BombController" Component
    [SerializeField]
    private float explosionDelay;

    private BoxCollider bc;

    private bool exploding;

    // Use this for initialization
    void Start () {
        exploding = false;

        bc = GetComponent<BoxCollider>();
        bc.isTrigger = true;

        // Create fuse
        Vector3 fuseOffset = new Vector3(0, 1, 0);
        fuseObject = Instantiate(fuseObject, gameObject.transform.position + fuseOffset, fuseObject.transform.rotation);

        // Explode function will be called after explosionDelay seconds
        Invoke("Explode", explosionDelay);
    }

    void OnTriggerExit(Collider other)
    {
        // if the Player exits the Trigger, the player won't be able to go back
        if (other.gameObject.tag.Equals("Player"))
            bc.isTrigger = false;
    }

    // destroy the object and spawn explosions!!!!
    public void Explode()
    {
        if (exploding)  // prevents infinte loop that would've resulted in a crash
            return;
        exploding = true;

        // x = E, z = N => directions = {N, E, S, W}
        Vector3[] directions = { new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(0, 0, -1), new Vector3(-1, 0, 0) };
        Vector3 explosionHeightOffset = new Vector3(0.0f, 0.5f);

        foreach (var direction in directions)
        {
            Vector3 startPoint = gameObject.transform.position;
            Vector3 endPoint = startPoint + direction * bombRange;

            // retains objects' info
            RaycastHit hitInfo;

            // If there is something in that direction
            if (Physics.Raycast(gameObject.transform.position, direction, out hitInfo, bombRange))
            {
                endPoint = hitInfo.point;

                if (hitInfo.transform.CompareTag("Breakable"))
                {
                    // TODO: Shatter the Wall
                    Destroy(hitInfo.transform.gameObject);
                }
                else if (hitInfo.transform.CompareTag("Bomb"))
                {
                    // Explode the hit bomb
                    hitInfo.transform.GetComponent<BombController>().Explode();
                }
                else if (hitInfo.transform.CompareTag("Player"))
                {
                    // TODO: End Game
                }
                else if (hitInfo.transform.CompareTag("Enemy"))
                {
                    // TODO: Call Enemy function OnHit()
                }
                else if (hitInfo.transform.CompareTag("PowerUp"))
                {
                    // TODO: Destroy the PowerUp
                }
            }

            // Create explosions from start point to end point
            for (Vector3 curPoint = startPoint; ; curPoint += direction)
            {
                float dist = Vector3.Distance(curPoint, endPoint);
                if (dist < 0.6f || dist > bombRange + 1.0f)
                    break;

                Instantiate(explosion, curPoint - explosionHeightOffset, Quaternion.identity);
            }
        }

        Destroy(fuseObject);

        Destroy(gameObject);
    }

    // Not working yet
    IEnumerator CreateExplosion(Vector3 startPoint, Vector3 endPoint, Vector3 direction)
    {
        for (Vector3 curPoint = startPoint; ; curPoint += direction)
        {
            float dist = Vector3.Distance(curPoint, endPoint);
            if (dist < 0.6f || dist > 30)
                break;

            Instantiate(explosion, curPoint, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
