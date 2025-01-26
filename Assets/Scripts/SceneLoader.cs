using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource click;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click.pitch = Random.Range(1f, 1.5f);
            click.Play();
        }
    }


    public void Quit()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadEnd()
    {
        SceneManager.LoadScene("End");
    }
}
