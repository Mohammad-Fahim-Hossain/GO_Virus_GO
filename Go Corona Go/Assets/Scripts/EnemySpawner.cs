using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float Range;
    public float Rate;
    public float RandomX;
    public static EnemySpawner EnemySpawnerInstance;


    private void Awake()
    {
        Enemy.GetComponent<Rigidbody2D>().gravityScale = .07f;

        if (EnemySpawnerInstance == null)
        {
            EnemySpawnerInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemySpawn() {

        RandomX = Random.Range(-Range, Range);

        Vector2 Position = new Vector2(RandomX, transform.position.y);

        Instantiate(Enemy, Position, Quaternion.identity);

    }

    public void StartSpawning() {

        InvokeRepeating("EnemySpawn", 1f, Rate);

    }

    public void StopSpawning() {

        CancelInvoke("EnemySpawn");

    }
}
