using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private void Start()
    {
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
}
