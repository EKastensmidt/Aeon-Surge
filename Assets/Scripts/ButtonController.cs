using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    gameObject.GetComponent<Renderer>().material.color = Color.green;

    //}
}
