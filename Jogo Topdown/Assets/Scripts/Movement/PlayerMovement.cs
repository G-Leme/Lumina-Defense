using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera cam;
   // public CharacterController controller;
    public float turnSmoothTime = 0.1f;
    [SerializeField] Animator animator;
    Rigidbody rb;

    private float turnSmoothVelocity;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

