using UnityEngine;

public class BombRangeScript : MonoBehaviour
{

    public float rangeStep;
    public float maxRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    void PickUp(Collider player)
    {
        // create little explosion on pickup??? idk

        // increase player speed
        float currentRange = player.GetComponent<PlayerBomb>().bombRange;
        if (currentRange < maxRange)
            player.GetComponent<PlayerBomb>().bombRange += rangeStep;

        // destroy pickup item
        Destroy(gameObject);
    }
}
