using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    bool isBoosted = false;
    public float multiplier;
    public float duration = 4f;
    PlayerMovement stats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        stats = player.GetComponent<PlayerMovement>();
        if (isBoosted == false)
        {
            isBoosted = true;
            SoundManagerScript.PlaySound("PowerUp");
            stats.jumpHeight *= multiplier;
            yield return new WaitForSeconds(duration);
            isBoosted = false;
            SoundManagerScript.PlaySound("PowerDown");
            stats.jumpHeight /= multiplier;
        }
    }
}
