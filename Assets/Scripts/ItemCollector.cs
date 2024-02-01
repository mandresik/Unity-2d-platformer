using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int bestTime;
    private float startTime;

    [SerializeField] private int oranges;

    [SerializeField] private int levelId;
    [SerializeField] private Text orangesText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text bestTimeText;

    [SerializeField] private AudioSource soundCollection;

    public int Oranges => oranges;
    public float StartTime => startTime;

    private void Start()
    {
        bestTime = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 1000);
        bestTimeText.text = "Level " + levelId.ToString() + " BEST: " + bestTime.ToString();
        startTime = Time.time;
        orangesText.text = "Oranges: " + oranges.ToString();
    }

    private void Update()
    {
        float elapsed = Time.time - startTime;
        timerText.text = "Time: " + ((int)elapsed).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            soundCollection.Play();

            Destroy(collision.gameObject);
            oranges--;
            orangesText.text = "Oranges: " + oranges;
        }
    }
}
