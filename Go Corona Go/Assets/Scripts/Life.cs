using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject LifePar;
    public GameObject GetLifePar;

    

    


  
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

            Instantiate(GetLifePar, transform.position, Quaternion.identity);
            GameManager.playerHealth = GameManager.playerHealth + 50;
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Ground")
        {
            if (!GameManager.Instance.IsOver)
            {
              Instantiate(LifePar, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
}
