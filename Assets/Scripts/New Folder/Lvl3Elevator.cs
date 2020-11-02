using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3Elevator : MonoBehaviour
{
    public GameObject anim;
    bool isActivated = true;
    private void OnTriggerEnter(Collider other)
    {
        if (isActivated == true)
        {
            Debug.Log("MOVE!!!");
            anim.GetComponent<Animation>().CrossFade("Elevator");
            isActivated = false;
        }
    }
}
