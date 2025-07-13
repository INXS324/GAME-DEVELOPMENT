using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject BulletPrefab;

    public Transform LeftBullet;
    public Transform RightBullet;

    private bool shoot = false;
    private Transform BulletSpawn;

    public float shootForce = 2000f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            BulletSpawnPos(); 
            shoot = true;     
        }
    }

    private void FixedUpdate()
    {
        if (shoot == true)
        {
            
            GameObject Bullet = Instantiate(
                BulletPrefab,
                BulletSpawn.position,
                BulletSpawn.rotation
            );

            
            Rigidbody rb = Bullet.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.left * shootForce);

            shoot = false;
        }
    }

    void BulletSpawnPos()
    {
        int random = Random.Range(0, 2); 
        BulletSpawn = (random == 0) ? LeftBullet : RightBullet;
    }
}
