using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public GameObject levelTutorial;
    public GameObject levelUno;
    public GameObject mainMenu;

    public void Tutorial()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}