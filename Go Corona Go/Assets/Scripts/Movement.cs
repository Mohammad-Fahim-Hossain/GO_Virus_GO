using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Movement : MonoBehaviour
{


    float DirX;
    public float MoveSpeed;
    Vector2 Newposition;
    Rigidbody2D RB;
    bool FaceLeft = true;
    Vector3 LocalScale;
    public float xLimit;

    public AudioClip VacEft;
    public AudioClip BonEft;
    public AudioClip LifEft;
    public AudioClip ShldEft;
    public AudioClip EnemyDes;

    private AudioSource VacSndEft;
    

    public float TempSpeed;

    public static Movement InstanceMovement;

    public GameObject SpeedTrailPar;
    public GameObject NormalTrailPar;
    public GameObject ShieldPar;

    public bool ShieldStatus;
    public bool bonusStatus;
    

    private float DirectX;
    private float MoveSpeedSensor=12;

    public bool ShieldActive=false;
    public bool BonusActive=false;
    public bool LifeActive=false;

 
    public bool AIspeedTrigger = true;

    public bool faceMovement = true;

   
    
  

    public void GameAI()
    {
        if (GameManager.Score >= 20)
        {
            BonusActive = true;
            
        }
        if (GameManager.Score >= 40)
        {
            ShieldActive = true;
        }
        if (GameManager.Score >= 60)
        {
            LifeActive = true;
        }


        if(GameManager.Score % 25 != 0 && AIspeedTrigger)
        {
            AIspeedTrigger = false;
        }


        if (GameManager.Score % 25 == 0 && AIspeedTrigger == false )
       {

            AIspeedTrigger = true;
           
  
           if (LifeActive)
           {
               LifeSpawner.LifeSpawnerInstance.Life.GetComponent<Rigidbody2D>().gravityScale = LifeSpawner.LifeSpawnerInstance.Life.GetComponent<Rigidbody2D>().gravityScale + 0.02f;
           }
           if (ShieldActive)
           {
               ShieldSpawner.ShieldSpawnerInstance.Shield.GetComponent<Rigidbody2D>().gravityScale = ShieldSpawner.ShieldSpawnerInstance.Shield.GetComponent<Rigidbody2D>().gravityScale + 0.02f;

           }
           if (BonusActive)
           {
               VaccineBonusSpawner.VaccineBonusSpawnerInstance.VaccineBonus.GetComponent<Rigidbody2D>().gravityScale = VaccineBonusSpawner.VaccineBonusSpawnerInstance.VaccineBonus.GetComponent<Rigidbody2D>().gravityScale + 0.02f;
           }

           VaccineSpawner.VaccineSpawnerInstance.Vaccine.GetComponent<Rigidbody2D>().gravityScale = VaccineSpawner.VaccineSpawnerInstance.Vaccine.GetComponent<Rigidbody2D>().gravityScale + 0.015f;
           EnemySpawner.EnemySpawnerInstance.Enemy.GetComponent<Rigidbody2D>().gravityScale= EnemySpawner.EnemySpawnerInstance.Enemy.GetComponent<Rigidbody2D>().gravityScale+0.04f;
            EnemySpawner.EnemySpawnerInstance.Enemy.GetComponent<Enemy>().RotateSpeed = EnemySpawner.EnemySpawnerInstance.Enemy.GetComponent<Enemy>().RotateSpeed - 0.1f;

           Debug.Log(EnemySpawner.EnemySpawnerInstance.Enemy.GetComponent<Rigidbody2D>().gravityScale);

        }
    

    }





    private void Awake()
    {
       

        SpeedTrailPar = this.gameObject.transform.GetChild(10).gameObject;
        NormalTrailPar = this.gameObject.transform.GetChild(11).gameObject;
        ShieldPar = this.gameObject.transform.GetChild(12).gameObject;

        LocalScale = transform.localScale;

        

        VacSndEft = this.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
  
        ShieldStatus = false;
        bonusStatus = false;
        NormalTrailPar.SetActive(true);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (InstanceMovement == null) {
            InstanceMovement = this;
        }

        RB = GetComponent<Rigidbody2D>();

        TempSpeed = MoveSpeedSensor;
    }

  

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Vaccine")
        {
            VacSndEft.PlayOneShot(VacEft);
        }

        if (collision.gameObject.tag == "Bonus")
        {
            bonusStatus = true;

            NormalTrailPar.SetActive(false);
            SpeedTrailPar.SetActive(true);

            VacSndEft.PlayOneShot(BonEft);
            StartCoroutine(InsSpeed());
            
        }

        if (collision.gameObject.tag == "Life")
        {
            VacSndEft.PlayOneShot(LifEft);

        }

        if (collision.gameObject.tag == "Shield") {
            ShieldStatus = true;

            NormalTrailPar.SetActive(false);
            ShieldPar.SetActive(true);
            VacSndEft.PlayOneShot(ShldEft);
            StartCoroutine(ShieldActivate());

        }

        if (collision.gameObject.tag == "Enemy" && ShieldStatus) 
        {
            VacSndEft.PlayOneShot(EnemyDes);
        }

    }

    IEnumerator ShieldActivate() {
        yield return new WaitForSeconds(10);

        ShieldStatus = false;
        ShieldPar.SetActive(false);

        if (!bonusStatus)
        {
            NormalTrailPar.SetActive(true);
        }
        



    }

    IEnumerator InsSpeed() {


        MoveSpeedSensor = 20f;

        yield return new WaitForSeconds(15);

        bonusStatus = false;
        MoveSpeedSensor = TempSpeed;
        SpeedTrailPar.SetActive(false);

        if (!ShieldStatus)
        {
            NormalTrailPar.SetActive(true);
        }
        
        
    }

    //Update is called once per frame
    void Update()
    {
      DirectX = Input.acceleration.x * MoveSpeedSensor;
      this.transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.2f, 2.2f), transform.position.y);

       GameAI();

    }




    private void FixedUpdate()
    {
        //Move();

       RB.velocity = new Vector2(DirectX, 0f);
    }

  /*
    void Move()
    {
        DirX = CrossPlatformInputManager.GetAxis("Horizontal");

        Newposition = transform.position;

        Newposition.x += DirX * MoveSpeed;

        Newposition.x =Mathf.Clamp(Newposition.x,-xLimit,xLimit);
        
        RB.MovePosition(Newposition);

    }
    */

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace() {
        if (DirectX > 0 && faceMovement)
            FaceLeft = false;
        else if (DirectX < 0 && faceMovement)
            FaceLeft = true;
        if (((FaceLeft) && (LocalScale.x < 0) && faceMovement) || ((!FaceLeft) && (LocalScale.x > 0) && faceMovement))
            LocalScale.x *= -1;

        transform.localScale = LocalScale;


 
    }


}
