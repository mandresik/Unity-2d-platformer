using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    [SerializeField] private AudioSource soundFinish;

    [SerializeField] private ItemCollector itemCollector;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && itemCollector.Oranges == 0)
        {
            Score();
            UnlockNewLevel();
            soundFinish.Play();
            Invoke("NextScene", 1.1f);
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene("Level Menu");
    }

    private void Score()
    {
        int score = (int)(Time.time - itemCollector.StartTime);
        int bestTime = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 1000);

        if (score < bestTime)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, score);
            PlayerPrefs.Save();
        }
    }

    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
