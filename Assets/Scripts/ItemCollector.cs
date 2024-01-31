using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private int oranges;
    [SerializeField] private Text orangesText;

    [SerializeField] private AudioSource soundCollection;


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
