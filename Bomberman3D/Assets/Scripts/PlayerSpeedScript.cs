using System.Collections;
using UnityEngine;

public class PlayerSpeedScript : MonoBehaviour
{
    public float pickUpDuration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider player)
    {
        // create little explosion on pickup??? idk

        // disable mesh render and collisions
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;

        // increase player speed
        float speed = player.GetComponent<PlayerMovement>().Speed;
        if (speed < 6.0f)
            player.GetComponent<PlayerMovement>().Speed += 3.0f;

        // wait for pickUpDuration seconds
        yield return new WaitForSeconds(pickUpDuration);

        // undo effect
        player.GetComponent<PlayerMovement>().Speed = speed;

        // destroy pickup item
        Destroy(gameObject);
    }
}
