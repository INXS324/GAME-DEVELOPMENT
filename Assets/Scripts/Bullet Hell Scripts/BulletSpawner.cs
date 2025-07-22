using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject BulletPrefab;
    public Transform spawnpoint;
    public float Bulletspeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBullet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBullet()
    {
        GameObject Bullet = Instantiate(
            BulletPrefab,
            spawnpoint.position,
            spawnpoint.rotation

            );

        Rigidbody2D bulletRb = Bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.down * Bulletspeed;



    }
}
