using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadTask1()
    {
        SceneManager.LoadScene("Task1");
    }

    public void LoadTask2()
    {
        SceneManager.LoadScene("Task2");
    }
}