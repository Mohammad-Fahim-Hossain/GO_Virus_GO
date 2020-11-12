using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineBonusSpawner : MonoBehaviour
{
    public GameObject VaccineBonus;
    public float Rate;
    public float RandomX;
    public float Range=2.23f;

    public static VaccineBonusSpawner VaccineBonusSpawnerInstance;


    private void Awake()
    {
        if (VaccineBonusSpawnerInstance == null)
        {
            VaccineBonusSpawnerInstance = this;
        }

        VaccineBonus.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        StartVaccineBonusSpawning();
    

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VaccineBonusSpawn()
    {

        if (Movement.InstanceMovement.BonusActive)
        {
            
            RandomX = Random.Range(-Range, Range);

            Vector2 Position = new Vector2(RandomX, transform.position.y);

            
                Instantiate(VaccineBonus, Position, Quaternion.identity);
            
        }
    }

    public void StartVaccineBonusSpawning()
    {

        InvokeRepeating("VaccineBonusSpawn", 1f, Rate);

    }

    public void StopVaccineBonusSpawning()
    {

        CancelInvoke("VaccineBonusSpawn");

    }



}
