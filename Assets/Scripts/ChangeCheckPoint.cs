﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCheckPoint : MonoBehaviour
{
    public GameObject checkPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(checkPoint);
        }
        Destroy(gameObject);
    }
}
