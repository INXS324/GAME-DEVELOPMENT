using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float jumpSpeed = 5f;
    private bool IsMoving = false;
    private Vector3 targetposition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetposition, jumpSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetposition) < 0.02f)
            {
                IsMoving = false;
            }
        }
    }

    public void Jump(Vector3 newposition)
    {
        if (! IsMoving)
        {
            targetposition = newposition;
            IsMoving = true;
        }
    }
}
