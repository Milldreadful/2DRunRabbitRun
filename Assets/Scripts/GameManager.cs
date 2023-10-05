using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator fadeScreen;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int levelNum)
    {
        StartCoroutine(FadeScreenLoad(levelNum));
    }

    public IEnumerator FadeScreenLoad(int levelNum)
    {
        fadeScreen.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelNum);
    }
}
