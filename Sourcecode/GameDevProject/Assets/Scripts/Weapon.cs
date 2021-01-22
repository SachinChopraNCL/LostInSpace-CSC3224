using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       if (Input.GetButton("Fire1"))
       {
            if (timer > 0.5)
             {
                Shoot();

                timer = 0;

            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
    }
}
