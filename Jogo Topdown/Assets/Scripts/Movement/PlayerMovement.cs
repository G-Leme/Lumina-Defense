using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] Animator animator;
   private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void FixedUpdate()
    {
        ProcessInputs();
    }


    void ProcessInputs()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        animator.SetFloat("Speed", direction.sqrMagnitude);
       rb.MovePosition(transform.position + direction * Time.deltaTime * moveSpeed);

    

        
    }

}

