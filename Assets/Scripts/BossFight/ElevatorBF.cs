﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBF : MonoBehaviour
{
    public GameObject elevator;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Move(-10000, 1f));
    }

    IEnumerator Move(float limit, float speed)
    {
        float counter = 0;
        while (counter > limit)
        {
            elevator.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            counter--;
            yield return null;
        }
    }
}
