using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    static bool toggle = true;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void View()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Start()
    {
       
    }
    public void ToggleSound()
    {
        toggle = !toggle;

        if (toggle)
            AudioListener.volume = 1f;

        else
            AudioListener.volume = 0f;
    }
}
