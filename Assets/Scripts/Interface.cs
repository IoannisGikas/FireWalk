using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interface : MonoBehaviour
{
    
    private TMP_Text CollectibleText;

    [SerializeField] Collectible collectible;
    private void Awake()
    {
        CollectibleText = GetComponent<TMP_Text>();
        collectible.onAddCollectible.AddListener(UpdateUI);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateUI(int amount)
    {
        CollectibleText.text = amount.ToString();
    }
    public void UpdateUI()
    {

    }
}
