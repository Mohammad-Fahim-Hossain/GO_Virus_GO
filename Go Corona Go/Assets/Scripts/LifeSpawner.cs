using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    public GameObject Life;
    public float Rate;
    public float RandomX;
    public float TempRandomX;

    public static LifeSpawner LifeSpawnerInstance;



    private void Awake()
    {
        if (LifeSpawnerInstance == null)
        {
            LifeSpawnerInstance = this;
        }

        Life.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartLifeSpawning();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LifeSpawn() {

       if (Movement.InstanceMovement.LifeActive)
      {
            TempRandomX = EnemySpawner.EnemySpawnerInstance.RandomX + 2f;
            RandomX = Random.Range(-TempRandomX, TempRandomX);

            Vector2 Position = new Vector2(RandomX, transform.position.y);

            if (-2.23 < RandomX && RandomX < 2.23 && GameManager.playerHealth < 100)
            {
                Instantiate(Life, Position, Quaternion.identity);

            }
        }
    }

    public void StartLifeSpawning()
    {

        InvokeRepeating("LifeSpawn", 1f, Rate);

    }

    public void StopLifeSpawning()
    {

        CancelInvoke("LifeSpawn");

    }

}
