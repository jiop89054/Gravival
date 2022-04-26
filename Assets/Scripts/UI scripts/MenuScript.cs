using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    static MenuScript instance;

    private void Awake()
    {
        instance = this;
    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);

    }
    public void Quit()
    {
        Application.Quit();
    }
}

