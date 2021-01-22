using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject player;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, firePoint.position) < 12 )
        {
            timer += Time.deltaTime;

            if (timer > 1.2)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        SoundManager.PlaySound("sentryshot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
