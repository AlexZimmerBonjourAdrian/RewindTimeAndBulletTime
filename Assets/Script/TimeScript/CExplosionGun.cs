using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExplosionGun : MonoBehaviour
{
    public GameObject explosion;
    public Camera cam;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
     if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit _hitInfo;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward,out _hitInfo))
        {
            Instantiate(explosion, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));
        }

    }
}
