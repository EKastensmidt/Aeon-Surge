using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    bool isBoosted = false;
    public float multiplier = 1.5f;
    public float duration = 4f;
    PlayerMovement stats;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup (Collider player)
    {
        stats = player.GetComponent<PlayerMovement>();
        if (isBoosted == false)
        {
            isBoosted = true;
            stats.speed *= multiplier;
            yield return new WaitForSeconds(duration);
            isBoosted = false;
            stats.speed /= multiplier;
        }
    }
}
