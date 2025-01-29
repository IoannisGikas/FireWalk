using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        selectedWeapon = 1;
        SelectWeapon(); 
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(ScrollWheel);

        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown("1"))
        {
            Debug.Log("Scrolled up");
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown("2"))
        {
            Debug.Log("Scrolled down");
            if (selectedWeapon <= transform.childCount - 1)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }
        if(previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    public void SelectWeapon()
    {
        int i = 0;
        foreach(Transform Weapon in transform)
        {
            if(i == selectedWeapon)
            {
                Weapon.gameObject.SetActive(true);
            }
            else
            {
                Weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
