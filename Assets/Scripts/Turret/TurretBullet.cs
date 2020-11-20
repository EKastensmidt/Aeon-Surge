using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurretBullet : MonoBehaviour
{
    public float movementSpeed;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
