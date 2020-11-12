using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject ShieldPar;

  

   


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

            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Ground")
        {
            if (!GameManager.Instance.IsOver)
            {
              Instantiate(ShieldPar, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
}
