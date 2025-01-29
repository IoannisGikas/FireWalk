using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    [SerializeField] PlayMove playMove;
    [SerializeField] CameraMove cameraMove;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] PlayerDash playerDash;
    [SerializeField] Gun gun;
    [SerializeField] GrapplingGun grappleGun;
    [SerializeField] GroundCheck groundCheck;

    public PauseMenu pauseMenu;
    


    void Update()
    {
        if (groundCheck.isGrounded == true && !grappleGun.IsGrappling()) // Jump input
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playMove.Jump();
            }
            //Vector3 movementDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                playMove.Movement();
            }
        
            if(!Input.anyKey) //&& !playerDash.IsDashing )
            {
                Debug.Log("Zeroing Speed");
                rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
                //rigidBody.velocity = Vector3.zero;
            }

        }
        else if(!grappleGun.IsGrappling())
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                //playMove.Left();
                playMove.AirMovement();
                //movementDirection.x = -1;
            }
        }

        if(grappleGun.isActiveAndEnabled == false)
        {
            grappleGun.StopGrapple();
        }
        

        playMove.directionalInput();
        /*
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerDash.Dash();
        }
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //playMove.Crouch();
        }
        
        */
        if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse X") < 0)
        {
            cameraMove.Look();
        }
        if (Input.GetAxis("Mouse Y") > 0 || Input.GetAxis("Mouse Y") < 0)
        {
            cameraMove.Look();
        }

        if (Input.GetMouseButtonDown(0) && gun.isActiveAndEnabled)
        {
            gun.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            //playMove.Interact();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (pauseMenu.isPaused)
            {
                pauseMenu.ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pauseMenu.PauseGame();
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
