using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject BulletPrefab;

    public Transform LeftBullet;
    public Transform RightBullet;


    private Transform BulletSpawn;

    public float shootForce = 2000f;

    

    public void FireBullet()
    {

        BulletSpawnPos();
        GameObject Bullet = Instantiate(
               BulletPrefab,
               BulletSpawn.position,
               BulletSpawn.rotation
           );


        Rigidbody rb = Bullet.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.left * shootForce);









    }

    void BulletSpawnPos()
    {
        int random = Random.Range(0, 2); 
        BulletSpawn = (random == 0) ? LeftBullet : RightBullet;
    }
}
