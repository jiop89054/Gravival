using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{


    // Start is called before the first frame update
    bool paused = false;
    public Canvas pauseCanv;
    public Canvas mainCanv;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseMenu();
        }
    }



    public void pauseMenu()
    {
        if (!paused)
        {
            Cursor.lockState = CursorLockMode.None;
            pauseCanv.gameObject.SetActive(true);
            mainCanv.gameObject.SetActive(false);
            Time.timeScale = 0;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            pauseCanv.gameObject.SetActive(false);
            mainCanv.gameObject.SetActive(true);
        }

        paused = !paused;
    }


    public void exit()
    {
        Application.Quit();
    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);

    }
}