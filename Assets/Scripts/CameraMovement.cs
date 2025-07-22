using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float Distance = 3f;
    public float smoothTime = 0.4f;
    private float Xcoords;
    private float Velocity = 0f;
    private bool moving = false;
   
    public void CameraMove()
    {
        moving = true;
        Xcoords = transform.position.x + Distance;
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            float ChangedX = Mathf.SmoothDamp(transform.position.x, Xcoords, ref Velocity, smoothTime);
            transform.position = new Vector3(ChangedX, transform.position.y, transform.position.z);

            if (Mathf.Abs(transform.position.x - Xcoords) <= 0.5f)
            {
                transform.position = new Vector3(ChangedX, transform.position.y, transform.position.z);
                moving = false;
                Velocity = 0f;
            }
        }
    }

    
}
