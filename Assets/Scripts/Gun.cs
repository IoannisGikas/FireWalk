using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage =10f;
    public float range = 100f;
    public float impactForce = 500000;
    
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private int ammo;
    private bool isReloading = false;
    private float timeToRotate = 1.01f;
    private float rotateTimer;
    private Vector3 gunRot;
    //[SerializeField] AnimationCurve rotationSpeedCurve;

    // Start is called before the first frame update
    void Start()
    {
        ammo = 5;
        rotateTimer = 0;
        gunRot = new Vector3 (0,this.transform.localEulerAngles.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ammo == 0)
        {   
            reload();
        }
        else
        {
        }
        
    }
    public void Shoot()
    {
        if (isReloading == false)   
        {
            muzzleFlash.Play();
            AudioManager.Singleton.PlaySoundEffect("PistolShot");
            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit, range))
            {
                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();
                if(target != null)
                {
                    target.TakeDamage(damage);
                }
            }
            //Debug.Log("Youve taken a shot");
            ammo -= 1;
            
            //hit effect will become child of hit
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            impactGO.transform.parent = hit.transform;
            if(hit.rigidbody != null)
            {
                Vector3 direction = hit.transform.position - Camera.main.transform.position;
                hit.rigidbody.AddForce(direction * impactForce);
                Debug.Log("Normal " + hit.normal + " Actual Force " + -hit.normal * impactForce);
                //AudioManager.Singleton.PlaySoundEffect("Ricochet");
            }
            Destroy(impactGO, 2f);
        }
        

    }
    private void reload()
    {
        if(isReloading == false)
        {
            AudioManager.Singleton.PlaySoundEffect("Reload");
        }
        isReloading = true;
        rotateTimer += Time.deltaTime;
        if (rotateTimer < timeToRotate)
        {
            this.transform.Rotate(Vector3.forward);
            Debug.Log("Youre reloading");
        }
        else
        {
            ammo = 5;
            rotateTimer = 0f;
            this.transform.localEulerAngles = gunRot;
            isReloading = false;
        }
        
    }
}
