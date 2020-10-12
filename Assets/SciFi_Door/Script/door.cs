using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class door : MonoBehaviour 
{
	GameObject theDoor;

    void OnTriggerEnter(Collider obj)
    {
        theDoor = GameObject.FindWithTag("SF_Door");
        theDoor.GetComponent<Animation>().Play("open");
    }

    //void OnTriggerExit(Collider obj)
    //{
    //    theDoor = GameObject.FindWithTag("SF_Door");
    //    theDoor.GetComponent<Animation>().Play("close");
    //}
}