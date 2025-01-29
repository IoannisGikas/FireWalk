using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayMove : MonoBehaviour
{
    private float moveSpeed = 15;
    private float airSpeed = 1;
    private float maxAirSpeed = 15;
    //private float maxGrappleSpeed = 5;

    [SerializeField] private float jumpForce = 1000;
    [SerializeField] private Transform orientationCam;

    private Rigidbody rigidBody;
    private float x, y;


    
    // Start is called before the first frame update
    void Start()
    {
        //caching
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void directionalInput()
    {
        y = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");
        
    }
    
    public void Movement()
    {
        
        Vector3 movement;
        movement = orientationCam.transform.forward * y * moveSpeed + orientationCam.transform.right * x * moveSpeed;
        movement.y = rigidBody.velocity.y;
        rigidBody.velocity = movement;

    }

    public void AirMovement()
    {
        rigidBody.AddForce(orientationCam.transform.forward * y * airSpeed + orientationCam.transform.right * x * airSpeed);
        rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxAirSpeed);
    }
    
    public void Jump()
    {
        //rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, rigidBody.velocity.z);
        rigidBody.AddForce(orientationCam.transform.up * jumpForce);
    }
     
}
