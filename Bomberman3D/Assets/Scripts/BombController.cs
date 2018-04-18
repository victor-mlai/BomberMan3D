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

    public ParticleSystem fuse;
    public ParticleSystem explosion;

    // SerializeField means that Unity will create a Field in the Editor so you can modify the attribute
    // click on Bomb prefab and you will see the field under "BombController" Component
    [SerializeField]
    private float explosionDelay;

    private BoxCollider bc;

    private ParticleSystem fuseObject;

    // Use this for initialization
    void Start () {
        bc = GetComponent<BoxCollider>();
        bc.isTrigger = true;

        Vector3 fuseOffset = new Vector3(0, 1, 0);
        ParticleSystem ps = Instantiate(fuse, gameObject.transform.position + fuseOffset, fuse.transform.rotation);
        ps.Stop(); // Cannot set duration whilst particle system is playing

        var main = ps.main;
        main.duration = explosionDelay;

        ps.Play();

        // Explode function will be called after explosionDelay seconds
        Invoke("Explode", explosionDelay);
    }

    private void OnTriggerExit(Collider other)
    {
        // if the Player exits the Trigger, the Trigger becomes a Collider
        if (other.gameObject.tag.Equals("Player"))
            bc.isTrigger = false;
    }

    // destroy the object and spawn explosions!!!!
    void Explode()
    {
        // x = E, z = N => directions = {N, E, S, W}
        Vector3[] directions = { new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(0, 0, -1), new Vector3(-1, 0, 0) };

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

                if (hitInfo.transform.tag == "Breakable")
                {
                    Destroy(hitInfo.transform.gameObject);
                }
                else if (hitInfo.transform.tag == "Player")
                {
                    // TODO: End Game
                }
                else if (hitInfo.transform.tag == "Bomb")
                {
                    // TODO: Explode the hit bomb
                }
            }

            // Create explosions from start point to end point
            for (Vector3 curPoint = startPoint; ; curPoint += direction)
            {
                float dist = Vector3.Distance(curPoint, endPoint);
                if (dist < 0.6f || dist > 30)
                    break;

                Instantiate(explosion, curPoint, Quaternion.identity);
            }
        }

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
