﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            isActivated = false;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            isActivated = true;
        }
    }
}
