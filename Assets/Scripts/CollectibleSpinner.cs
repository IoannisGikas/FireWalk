using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpinner : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if (gameObject.CompareTag("Collectible"))
        {
            this.transform.Rotate(Vector3.up);
        }

    }
}
