using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Tuto");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
