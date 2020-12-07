using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private ChangeCheckPoint cp;
    private void Start()
    {
        cp = GameObject.FindGameObjectWithTag("CP").GetComponent<ChangeCheckPoint>();
        transform.position = cp.lastCheckPoint;
    }
}
