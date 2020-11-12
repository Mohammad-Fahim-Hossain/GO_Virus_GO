using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineSpawner : MonoBehaviour
{
    public GameObject Vaccine;
    public float Rate;
    public float RandomX;
    public float TempRandomX;

    public static VaccineSpawner VaccineSpawnerInstance;


    private void Awake()
    {
        if (VaccineSpawnerInstance == null)
        {
            VaccineSpawnerInstance = this;
        }

        Vaccine.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
    }


    // Start is called before the first frame update
    void Start()
    {

        StartVaccineSpawning();

     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VaccineSpawn() {


        TempRandomX = EnemySpawner.EnemySpawnerInstance.RandomX + 2f;
        RandomX = Random.Range(-TempRandomX, TempRandomX);
      
        Vector2 Position = new Vector2(RandomX, transform.position.y);

        if (-2.23 < RandomX && RandomX < 2.23)
        {
            Instantiate(Vaccine, Position, Quaternion.identity);
        }
    }

    public void StartVaccineSpawning()
    {

        InvokeRepeating("VaccineSpawn", 1f, Rate);

    }

    public void StopVaccineSpawning()
    {

        CancelInvoke("VaccineSpawn");

    }

}
