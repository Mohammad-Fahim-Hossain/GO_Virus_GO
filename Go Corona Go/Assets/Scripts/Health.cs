using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Image HealthBar;

   


    // Start is called before the first frame update
    void Start()
    {
        HealthBar = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = GameManager.playerHealth / 100f;
        
    }
}
