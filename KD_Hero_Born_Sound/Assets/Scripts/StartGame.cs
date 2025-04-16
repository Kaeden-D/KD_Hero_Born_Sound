using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public void LoadNextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void InvokeNextLevel(float time)
    {

        Invoke("LoadNextLevel", time);

    }

    public void LoadFirstLevel()
    {

        Debug.Log("Tset");
        SceneManager.LoadScene(1);

    }

    public void InvokeFirstLevel(float time)
    {

        Debug.Log("Test");
        Invoke("LoadFirstLevel", time);

    }

}
