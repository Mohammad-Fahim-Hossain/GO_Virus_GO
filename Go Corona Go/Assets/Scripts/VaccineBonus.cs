using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineBonus : MonoBehaviour
{
    public GameObject VacBonusPar;
    public GameObject GetVacBonusPar;



    

   
  

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

            Instantiate(GetVacBonusPar, transform.position, Quaternion.identity);
           GameManager.Instance.BonusScore();
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Ground")
        {
            if (!GameManager.Instance.IsOver)
            {
              Instantiate(VacBonusPar, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
}
