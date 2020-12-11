using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFButtons : MonoBehaviour
{
    public static bool isActivated = false;
    public GameObject anim;
    private void OnTriggerEnter(Collider other)
    {
        if(isActivated == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            BFButtons.isActivated = false;
            anim.GetComponent<Animation>().CrossFade("BFActivate");
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            BFButtons.isActivated = true;
            anim.GetComponent<Animation>().CrossFade("BFDeactivate");
        }
    }
}
