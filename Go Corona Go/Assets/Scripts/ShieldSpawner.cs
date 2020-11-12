using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject Shield;
    public float Rate;
    public float RandomX;
    public float Range= 2.23f;

    public static ShieldSpawner ShieldSpawnerInstance;


    private void Awake()
    {
        if (ShieldSpawnerInstance == null)
        {
            ShieldSpawnerInstance = this;
        }

        Shield.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
    }


    // Start is called before the first frame update
    void Start()
    {

        StartShieldSpawning();

     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShieldSpawn() {

        if ( Movement.InstanceMovement.ShieldActive) {

            RandomX = Random.Range(-Range, Range);

            Vector2 Position = new Vector2(RandomX, transform.position.y);

            
                Instantiate(Shield, Position, Quaternion.identity);
            
        }
    }

    public void StartShieldSpawning()
    {

        InvokeRepeating("ShieldSpawn", 1f, Rate);

    }

    public void StopShieldSpawning()
    {

        CancelInvoke("ShieldSpawn");

    }

}
