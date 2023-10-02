using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
    }

    public void Mute()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
        }

        else
        {
            backgroundMusic.Play();
        }
    }
}
