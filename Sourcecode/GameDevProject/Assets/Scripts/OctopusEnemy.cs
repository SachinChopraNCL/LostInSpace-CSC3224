using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusEnemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public Transform spawnPoint;
    public GameObject healthPreFab;

    void Start()
    {
        transform.position = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Despawn();
    }

    void Despawn()
    {
        int dir = Random.Range(0, 9);

    

        SoundManager.PlaySound("death");
        Instantiate(deathEffect, transform.position, transform.rotation);

        if (dir == 0)
        {
            Instantiate(healthPreFab, transform.position, transform.rotation);

        }

        Destroy(gameObject);
    }

}