using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDash : MonoBehaviour
{
    
    public float speed = 1000f;
    [SerializeField] float dashCooldown = 3;
    bool isDashing = false;

    public bool IsDashing => isDashing;

    private float timer = 0;
    void Update()
    {
        if (!isDashing) return;

        timer += Time.deltaTime;

        if(timer >= dashCooldown)
        {
            isDashing = false;
        }
          
    }
    public void Dash()
    {
        if (isDashing) return;  //Does check only if we are not dashing

        transform.position += new Vector3(speed * Time.deltaTime, 0.1f, 0.0f);
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        timer = 0;
        isDashing = true;
        
    }
        
}

