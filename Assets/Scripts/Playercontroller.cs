using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;



public class Playercontroller : MonoBehaviour
{
    public float jumpForce = 10f;

    private Rigidbody rb;
    private Vector3 nextPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void JumpTarget(Vector3 targetPosition)
    {
        rb.constraints = RigidbodyConstraints.None;

        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.velocity = direction * jumpForce;
        nextPosition = targetPosition;
    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Platform"))
        {

            Debug.Log("Landed on platform!");


            Vector3 Centre = new Vector3(
                nextPosition.x,
                nextPosition.y,
                nextPosition.z

             );

            transform.position = Centre;

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;


            rb.constraints = RigidbodyConstraints.FreezeAll;
            FindObjectOfType<Gamemanager>().PlayerLanded();


        }


    }
}