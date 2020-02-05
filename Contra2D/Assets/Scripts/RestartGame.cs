using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public GameObject menu;
    public void RestartGames()
    {
        menu.SetActive(false);
        SceneManager.LoadScene(0);
        //Application.LoadLevel(0);
        Time.timeScale = 1;
    }
}
