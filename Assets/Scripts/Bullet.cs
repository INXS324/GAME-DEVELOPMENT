using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

      
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Gamemanager>().OnPlayerHit();
            Destroy(gameObject);

            FindObjectOfType<Gamemanager>().BulletFinished();
        }

        
    }

    private void OnBecameInvisible()
    {
        FindObjectOfType<Gamemanager>().BulletFinished();
        Destroy(gameObject);
    }
}


