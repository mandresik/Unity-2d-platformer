using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private float startTime;

    [SerializeField] private int oranges;

    [SerializeField] private Text orangesText;
    [SerializeField] private Text timerText;

    [SerializeField] private AudioSource soundCollection;

    public int Oranges => oranges;

    private void Start()
    {
        startTime = Time.time;        
    }

    private void Update()
    {
        int elapsed = (int)Time.time - (int)startTime;
        timerText.text = "Time: " + elapsed.ToString();
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
