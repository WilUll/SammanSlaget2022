using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void GameScene()
    {
        GameManager.MoneyCollected = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void MenuScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
