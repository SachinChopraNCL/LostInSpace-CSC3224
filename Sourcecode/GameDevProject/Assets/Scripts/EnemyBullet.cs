using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Vector3 moveDirection = (player.transform.position - transform.position);
        moveDirection.Normalize();
        rb.velocity = moveDirection * speed ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerBehaviour playerInfo = hitInfo.GetComponent<PlayerBehaviour>();
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        OctopusEnemy octoEnemy = hitInfo.GetComponent<OctopusEnemy>();

        if (!enemy && !octoEnemy)
        {
            if (playerInfo != null)
            {
                playerInfo.lives--;
                playerInfo.isHurt = true;
                ScoreScript.lives = ScoreScript.lives - 1;

            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
      
    }
}
