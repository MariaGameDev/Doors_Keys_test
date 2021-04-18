using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMovement();
    }



    void PlayerMovement()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical"); 

         rb.velocity = new Vector3(xMove * speed, rb.velocity.y, zMove * speed) * Time.deltaTime;

       
    }
	
}
