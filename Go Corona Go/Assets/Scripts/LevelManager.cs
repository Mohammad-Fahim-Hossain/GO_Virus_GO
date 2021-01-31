using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public GameObject PauseManu = null;
    public GameObject PauseButton = null;
    public GameObject ContinueButton = null;
    


    private void Start()
    {
       
      

        if (SceneManager.GetActiveScene().name == "Main")
        {
            if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork || Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                ContinueButton.SetActive(true);
            }
            else
            {
                ContinueButton.SetActive(false);
            }
            
            PauseManu.SetActive(false);
            PauseButton.SetActive(true);
           
            Invoke("MainSceneBannerAd", 10f);
        }

        

        if (SceneManager.GetActiveScene().name == "Manu")
        {
            AdsManuManager.adsManuManagerInstance.RequestBanner();
        }

        
    }

    void MainSceneBannerAd()
    {
        AdsManuManager.adsManuManagerInstance.RequestBanner();
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
        Movement.InstanceMovement.faceMovement = false;
        PauseManu.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Movement.InstanceMovement.faceMovement = true;
        PauseManu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void ShowRewardVideo()
    {
        ContinueButton.SetActive(false);
        AdsManuManager.adsManuManagerInstance.RewardedADshow();
    }
}
