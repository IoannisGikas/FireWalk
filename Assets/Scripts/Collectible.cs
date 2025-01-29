using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    private int currentCollectibles;

    public UnityEvent<int> onAddCollectible;
    
    public void AddCollectible(int amount)
    {
        currentCollectibles += amount;
        onAddCollectible?.Invoke(currentCollectibles);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            AddCollectible(1);
            Debug.Log("Youve found a collectible");
            Destroy(other.gameObject);
        }

    }
}
