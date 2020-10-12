using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colliding");
        Destroy(this.gameObject);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("colliding");

        Destroy(this.gameObject);   
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("colliding");

        if (collision.transform.name == "Player") Destroy(gameObject);
    }
    
}
