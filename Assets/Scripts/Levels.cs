using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public GameObject levelTutorial;
    public GameObject levelUno;
    public GameObject levelDos;
    public GameObject levelTres;
    public GameObject levelCuatro;
    public GameObject bossFight;
    public GameObject mainMenu;

    public void Tutorial()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void BossFight()
    {
        SceneManager.LoadScene("BossFight");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}