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

      
        rb.velocity = Vector3.left * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Gamemanager>().OnPlayerHit();
        }

        Destroy(gameObject);
    }
}


