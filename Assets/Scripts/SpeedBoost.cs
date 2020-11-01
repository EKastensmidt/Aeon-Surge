using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    bool isBoosted = false;
    public float multiplier = 1.5f;
    public float duration = 4f;
    PlayerMovement stats;
    public Camera cam;
    
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
            stats.speed *= multiplier;
            cam.fieldOfView = 65f;
            yield return new WaitForSeconds(duration);
            isBoosted = false;
            SoundManagerScript.PlaySound("PowerDown");
            stats.speed /= multiplier;
            cam.fieldOfView = 60f;
        }
    }
}
