using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Mud;
    public GameObject EnemyPar;

 




    public float RotateSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        transform.Rotate(0, 0, RotateSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {

            if (!Movement.InstanceMovement.ShieldStatus)
            {


                Movement.InstanceMovement.MoveSpeed = Movement.InstanceMovement.TempSpeed;
                Movement.InstanceMovement.SpeedTrailPar.SetActive(false);
                Movement.InstanceMovement.NormalTrailPar.SetActive(true);

                GameManager.Instance.GameOver();

                if (!GameManager.Instance.IsOver)
                {

                    Instantiate(EnemyPar, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
                else
                {
                    Instantiate(EnemyPar, transform.position, Quaternion.identity);
                    Destroy(collision.gameObject);
                }
            }

            else {
          
                Instantiate(Mud, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);

                
            }
        }


        else if (collision.gameObject.tag == "Ground")
        {

            if (!GameManager.Instance.IsOver)
            {
                Instantiate(Mud, this.transform.position, Quaternion.identity);
            }
       
            Destroy(this.gameObject);

        }
       
    }


}
