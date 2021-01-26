using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public GameObject PauseManu = null;
    public GameObject PauseButton = null;

    private void Start()
    {
        PauseManu.SetActive(false);
        PauseButton.SetActive(true);

        if (SceneManager.GetActiveScene().name == "Manu")
        {
            AdsManuManager.adsManuManagerInstance.RequestBanner();
        }
    }

    public void HideBannerAd()
    {
        AdsManuManager.adsManuManagerInstance.HideBanner();
    }

    public void Manu()
    {
        
        SceneManager.LoadScene("Manu");
    }

    public void ReStart()
    {
       
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseManu.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        PauseManu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }
}
