using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsOver = false;
    public static int Score;
    public int TempScore;
   
    public Text ScoreText;
    public GameObject MainCamera;
    private AudioSource bgMusic;
    private GameObject Par;

    public AudioClip Cough1;
    public AudioClip Cough2;


    public GameObject ContinueButton;
    private int ContinueButtonTrigger;

    private bool GameOverPanelActivate = false;

    public static float playerHealth;

    public GameObject GameOverPanel;
    public Text GameOverText;
    public GameObject HealthUI;

    private GameObject Enem;
    private GameObject Vac;
    private GameObject VacBon;
    private GameObject Life;
    private GameObject Shield;

    private void Awake()
    {
        if (Instance == null) {

            Instance = this;
        }

        Score = 0;

        bgMusic = MainCamera.GetComponent<AudioSource>();
        bgMusic.pitch = 0.9f;

        
    }

    // Start is called before the first frame update
    void Start()
    {
        AdsManuManager.adsManuManagerInstance.ReqFullScreenAd();
        

        ContinueButtonTrigger = 0;
        playerHealth = 100f;
        InvokeRepeating("ParticleDes", 1f, 0.45f);

    }

    // Update is called once per frame
    void Update()
    {

        soundAI();

        Par = GameObject.FindGameObjectWithTag("par");

        Enem = GameObject.FindGameObjectWithTag("Enemy");
        Vac = GameObject.FindGameObjectWithTag("Vaccine");
        VacBon = GameObject.FindGameObjectWithTag("Bonus");
        Life = GameObject.FindGameObjectWithTag("Life");
        Shield = GameObject.FindGameObjectWithTag("Shield");

        if (GameOverPanelActivate)
        {
            StartCoroutine(GameOverPanelAct());
        }
    }

    IEnumerator GameOverPanelAct()
    {
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(true);
        GameOverPanelActivate = false;


    }

    public void soundAI()
    {
        if (Score >= 25&& Score < 50)
        {
            bgMusic.pitch = 0.95f;
            
        }
        if (Score >= 100 && Score < 200)
        {
            bgMusic.pitch = 1f;
            
        }
        if (Score >= 200 && Score < 200)
        {
            bgMusic.pitch = 1.05f;
            
        }
        if (Score >= 250)
        {
            bgMusic.pitch = 1.1f;
    
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void ParticleDes()
    {
        Destroy(Par);
    }


    public void GameOver()
    {

        playerHealth = playerHealth - 50f;

        if (playerHealth == 0f)
        {
            IsOver = true;
            GameOverPanelActivate = true;

            this.gameObject.GetComponent<AudioSource>().PlayOneShot(Cough2);

            
            bgMusic.pitch = 0.8f;

            GameObject.Find("VaccineSpawner").GetComponent<VaccineSpawner>().StopVaccineSpawning();
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().StopSpawning();
            GameObject.Find("VaccineBonusSpawner").GetComponent<VaccineBonusSpawner>().StopVaccineBonusSpawning();
            GameObject.Find("LifeSpawner").GetComponent<LifeSpawner>().StopLifeSpawning();
            GameObject.Find("ShieldSpawner").GetComponent<ShieldSpawner>().StopShieldSpawning();


            AdsManuManager.adsManuManagerInstance.ShowFullScreenAd();
            

            GameOverText.text = Score.ToString();
            
            ScoreText.gameObject.SetActive(false);
            HealthUI.SetActive(false);

            TempScore = Score;

           
            InvokeRepeating("DesObject", 1f, 0.1f);

            ContinueButtonTrigger++;

           if (ContinueButtonTrigger == 3)
            {
                ContinueButton.SetActive(false);
            }
            

        }
        if (playerHealth == 50f)
        {
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(Cough1);
        }
    }

    public void StopDesObject()
    {

        CancelInvoke("DesObject");

    }


    public void DesObject()
    {
        Destroy(Enem);
        Destroy(Vac);
        Destroy(VacBon);
        Destroy(Life);
        Destroy(Shield);

    }


    public void IncScore() {
       

            Score++;

            ScoreText.text = Score.ToString();
            

        
    }

    public void BonusScore() {


           Score=Score+5;

           ScoreText.text = Score.ToString();

    }
}
