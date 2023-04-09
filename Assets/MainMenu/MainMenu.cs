using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
    }
    public void QuitGame() {
        {
            Application.Quit();
        }
    }
    public void backToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void goToSetting()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Setting Menu");
    }

    public void goToAbout()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Abouts Menu");
    }
    public void loadLevel_1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }
        public void loadLevel_2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }
        public void loadLevel_3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
    }
}
