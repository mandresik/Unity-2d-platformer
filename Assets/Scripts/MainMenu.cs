using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource soundButton;
    public void LevelMenu()
    {
        soundButton.Play();
        Invoke("DoLevelMenu", .25f);
    }

    public void About()
    {
        soundButton.Play();
        Invoke("DoAbout", .25f);
    }

    public void Quit()
    {
        soundButton.Play();
        Invoke("DoQuit", .25f);
    }

    private void DoLevelMenu()
    {
        SceneManager.LoadScene("Level Menu");
    }

    private void DoAbout()
    {
        SceneManager.LoadScene("About");
    }

    private void DoQuit()
    {
        Application.Quit();
    }
}
