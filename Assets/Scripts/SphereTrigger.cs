using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SphereTrigger : MonoBehaviour
{

    [SerializeField] private Rigidbody Sphere;
    // Start is called before the first frame update
    void Start()
    {
        Sphere.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Sphere.useGravity = true;
        }
    }
}
