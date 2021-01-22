using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CharacterController2D controller;

    public int health = 100;
    public float moveSpeed = 25;
    public float horizontalMove = 0f;
    public GameObject deathEffect;
    public Animator animator;
    private float timer = 0f;
    Vector3 OldPosition = new Vector3(-1000, -1000, -1000);
    private enum Direction
    {
        LEFT = -1,
        RIGHT = 1,
        NONE = 0
    }
    private Direction currDir = Direction.NONE;
    public Transform leftSpawn;
    public Transform rightSpawn;
    public Transform loopLeft;
    public Transform loopRight;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("IsWalking", true);

        int spawnPoint = Random.Range(0, 2);
        if (spawnPoint == 0)
        {
            controller.InitLeftFlip();
            transform.position = leftSpawn.position;
            currDir = Direction.RIGHT;
        }
        else if (spawnPoint == 1)
        {
            controller.InitRightFlip();
            transform.position = rightSpawn.position;
            currDir = Direction.LEFT;
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Despawn();
    }


    void Despawn()
    {
        SoundManager.PlaySound("death");

        Instantiate(deathEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 7)
        {
            int dir = Random.Range(0, 2);
            if (dir == 0)
            {
                currDir = Direction.LEFT;
            }
            else if (dir == 1)
            {
                currDir = Direction.RIGHT;
            }


            timer = 0;
        }


        if (transform.position == OldPosition)
        {
            if (currDir == Direction.LEFT)
            {
                currDir = Direction.RIGHT;
            }
            else if (currDir == Direction.RIGHT)
            {
                currDir = Direction.LEFT;
            }
        }

        if (transform.position.x <= loopLeft.position.x)
        {
            transform.position = loopRight.position;
        }
        else if (transform.position.x >= loopRight.position.x)
        {
            transform.position = loopLeft.position;
        }

        horizontalMove = ((float)currDir) * moveSpeed;


    }

    void FixedUpdate()
    {
        OldPosition = transform.position;
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }


}
