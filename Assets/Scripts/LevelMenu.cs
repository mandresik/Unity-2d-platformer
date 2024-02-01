using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject levelButtons;

    [SerializeField] private AudioSource soundButton;

    private void Awake()
    {
        ButtonsToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for(int i = 0; i < buttons.Length; ++i)
        {
            buttons[i].interactable = false;
        }

        for(int i = 0; i < unlockedLevel; ++i)
        {
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel(int levelId)
    {
        soundButton.Play();
        string levelName = "Level " + levelId.ToString();
        SceneManager.LoadScene(levelName);
    }

    private void ButtonsToArray()
    {
        int childCount = levelButtons.transform.childCount;
        buttons = new Button[childCount];

        for(int i = 0; i < childCount; ++i)
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }

    public void Menu()
    {
        soundButton.Play();
        Invoke("MainMenu", .25f);
        
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
