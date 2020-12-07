using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private ChangeCheckPoint cp;
    private void Start()
    {
        cp = GameObject.Find("CP").GetComponent<ChangeCheckPoint>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            cp.lastCheckPoint = transform.position;
        }
    }
}
