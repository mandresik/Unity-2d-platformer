using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class About : MonoBehaviour
{
    [SerializeField] private AudioSource soundButton;

    public void Menu()
    {
        soundButton.Play();
        Invoke("DoMenu", .25f);
    }

    private void DoMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
