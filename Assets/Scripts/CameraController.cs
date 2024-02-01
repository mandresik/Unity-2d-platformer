using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private AudioSource soundButton;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    public void LevelMenu()
    {
        soundButton.Play();
        Invoke("NextScene", .22f);
    }

    private void NextScene()
    {
        SceneManager.LoadScene("Level Menu");
    }
}
