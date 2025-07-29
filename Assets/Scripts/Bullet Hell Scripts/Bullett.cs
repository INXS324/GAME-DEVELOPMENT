using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullett : MonoBehaviour
{

    public Vector2 direction;
    public float startspeed;
    public float maxspeed;
    public float delay;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * startspeed;
        StartCoroutine(SpeedBoost());
        
    }

    IEnumerator SpeedBoost()
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = direction.normalized * maxspeed;
    }


    
    


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Boundary") || other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
