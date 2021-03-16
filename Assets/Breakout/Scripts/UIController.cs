using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject WinnerScreen;
    [SerializeField] GameObject[] hearts;
    [SerializeField] Text gameTimeUI;
    [SerializeField] AudioController audioController;
    [SerializeField] AudioClip buttonPressedSfx;
    [SerializeField] AudioClip loseLifeSfx;


    public void AvtivateLoseScreen()
    {
        audioController.UpdateMusicVolume(0.5f);
        loseScreen.SetActive(true);
    }

    public void AvtivateWinnerScreen()
    {
        audioController.UpdateMusicVolume(0.5f);
        WinnerScreen.SetActive(true);
    }


    public void TryAgain()
    {
        audioController.PlaySfx(buttonPressedSfx);
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        audioController.PlaySfx(buttonPressedSfx);
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        audioController.PlaySfx(buttonPressedSfx);
        SceneManager.LoadScene("NextLevel");
    }

    public void NextLevel2()
    {
        audioController.PlaySfx(buttonPressedSfx);
        SceneManager.LoadScene("NextLevel2");
    }

    public void NextLevel3()
    {
        audioController.PlaySfx(buttonPressedSfx);
        SceneManager.LoadScene("NextLevel3");
    }

    public void NextLevel4()
    {
        audioController.PlaySfx(buttonPressedSfx);
        SceneManager.LoadScene("NextLevel4");
    }


    public void UpdateLives(int currenteLives)
    {
        for (int i =0; i< hearts.Length; i++)
        {
            if (i >= currenteLives)
            {
                hearts[i].SetActive(false);
            }
        }
        audioController.PlaySfx(loseLifeSfx);
    }

    public void UpdateTime(float gameTime)
    {
        gameTimeUI.text = "Time: " + Mathf.Floor(gameTime) + " seconds";
    }


}
