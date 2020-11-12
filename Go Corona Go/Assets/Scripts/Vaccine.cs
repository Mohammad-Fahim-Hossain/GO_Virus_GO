using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    public GameObject VacPar;
    public GameObject GetVacPar;

 
    

   

    // Start is called before the first frame update
    void Start()
    {
      
  
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Instantiate(GetVacPar, transform.position, Quaternion.identity);
            GameManager.Instance.IncScore();
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Ground")
        {
            if (!GameManager.Instance.IsOver)
            {
                Instantiate(VacPar, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }

}
