using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{
    string currentScene;

    private void OnTriggerEnter(Collider other)
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (other.gameObject.name == "Player")
        {
            if (currentScene == "SampleScene")
            {
                SceneManager.LoadScene("Level1");
            }
            else if (currentScene == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (currentScene == "Level2")
            {
                SceneManager.LoadScene("Menu");
                Cursor.lockState = CursorLockMode.Confined;

            }
        }   
    }
}
