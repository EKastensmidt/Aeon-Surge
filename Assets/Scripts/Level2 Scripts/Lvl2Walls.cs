using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2Walls : MonoBehaviour
{
    public bool isActivated = false;
    public GameObject anim;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            isActivated = false;
            anim.GetComponent<Animation>().CrossFade("WallDeactivate");
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            isActivated = true;
            anim.GetComponent<Animation>().CrossFade("WallActivate");
        }
    }
}
