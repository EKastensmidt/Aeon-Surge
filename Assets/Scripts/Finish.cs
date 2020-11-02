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
                SceneManager.LoadScene("Level3");
            }
            else if (currentScene == "Level3")
            {
                //SceneManager.LoadScene("Level4");
                SceneManager.LoadScene("Menu");
                Cursor.lockState = CursorLockMode.None;
            }
            else if (currentScene == "Level4")
            {
                //SceneManager.LoadScene("Level5");
                SceneManager.LoadScene("Menu");
                Cursor.lockState = CursorLockMode.None;
            }
        }   
    }
}
