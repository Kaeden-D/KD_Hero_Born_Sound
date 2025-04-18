using System.Xml.Serialization;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public static bool game_paused = false;

    public GameObject UI;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (game_paused)
            {
                Debug.Log("resume1");
                resume();

            }
            else
            {
                Debug.Log("pause1");
                pause();

            }

        }

    }

    public void resume()
    {
        Debug.Log("resume2");
        UI.SetActive(false);
        Time.timeScale = 1f;
        game_paused = false;

    }

    public void pause()
    {
        Debug.Log("pause2");
        UI.SetActive(true);
        Time.timeScale = 0f;
        game_paused = true;

    }
}
