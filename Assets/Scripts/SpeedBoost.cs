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
            StartCoroutine(FromTo(60f, 75f, 0.2f, false));
            yield return new WaitForSeconds(duration);
            isBoosted = false;
            SoundManagerScript.PlaySound("PowerDown");
            StartCoroutine(FromTo(stats.speed, stats.speed/multiplier, 0.7f, true));
            StartCoroutine(FromTo(75f, 60f, 0.7f, false));
        }
    }

    IEnumerator FromTo(float from, float to, float delay, bool speed)
    {
        float counter = 0;
        while(counter < delay)
        {
            counter += Time.deltaTime;
            if (counter > delay) counter = delay;
            float value = from + (to - from) * (counter / delay);
            if (speed)
            {
                stats.speed = value;
            } else
            {
                cam.fieldOfView = value;
            }

            yield return null;
        }
    }
}
