using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    private ChangeCheckPoint cp;
    private void Start()
    {
        cp = GameObject.Find("CP").GetComponent<ChangeCheckPoint>();
        transform.position = cp.lastCheckPoint;
    }

    private void Update()
    {
        if (transform.position.y < -50 || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
