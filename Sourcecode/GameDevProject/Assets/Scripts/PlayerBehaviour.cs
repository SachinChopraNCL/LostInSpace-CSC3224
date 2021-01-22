using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float horizontalMove = 0f;
    public float runSpeed = 40f;
    public int lives = 5;
    bool jump = false;
    public bool isHurt = false;
    public int heldFuel = 0;
    public int maxFuel = 20;
    public int fuelVal = 5;
    private float hurtTimer = 0f;
    public Transform leftBound;
    public Transform rightBound;
    public FuelBarScript fuelBar;
    private bool godMode = false;
   
    void Start()
    {
        heldFuel = 0;
        lives = 5;
        godMode = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            lives = 999;
            ScoreScript.lives = 999;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            heldFuel = maxFuel;
            fuelBar.SetFuel(heldFuel);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (godMode)
                godMode = false;
            else
            {
                godMode = true;
                gameObject.layer = LayerMask.NameToLayer("Ghost");

            }
        }

        if (isHurt && !godMode)
        {
            if(hurtTimer == 0)
            {
                SoundManager.PlaySound("hurt");
            }
           
            hurtTimer += Time.deltaTime;
            if(hurtTimer > 0.5)
            {
                isHurt = false;
                animator.SetBool("IsHurt", isHurt);
                gameObject.layer = LayerMask.NameToLayer("Default");
                hurtTimer = 0;
            }
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            SoundManager.PlaySound("jump");
        }

        if (Mathf.Abs(horizontalMove) > 0.05 && Input.GetButton("Fire1"))
        {
            animator.SetBool("Shooting", true);
        }
        else
        {
            animator.SetBool("Shooting", false);
        }

  

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        bool inbounds = transform.position.x > leftBound.position.x && transform.position.x < rightBound.position.x;
        bool moveAwayLeft = transform.position.x < leftBound.position.x && horizontalMove > 0;
        bool moveAwayRight = transform.position.x > rightBound.position.x && horizontalMove < 0;
        if (inbounds || moveAwayLeft || moveAwayRight)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        }
        jump = false;
        if (lives <= 0)
        {
            SceneManager.LoadScene("You_Lose");
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.gameObject.name == "Fuel1(Clone)")
        {
            heldFuel += fuelVal;

            if (heldFuel < maxFuel)
            {
                Destroy(hitInfo.gameObject);
                SoundManager.PlaySound("pickup");

            }

            if (heldFuel > maxFuel)
                heldFuel = maxFuel;


            fuelBar.SetFuel(heldFuel);
        }

        if (hitInfo.gameObject.name == "Health(Clone)")
        {
            lives++;
            ScoreScript.lives = ScoreScript.lives + 1;
            Destroy(hitInfo.gameObject);
            SoundManager.PlaySound("health");
        }



    }

    void OnTriggerStay2D(Collider2D hitInfo)
    {
        
        OctopusEnemy octoEnemy = hitInfo.GetComponent<OctopusEnemy>();
        if (octoEnemy != null)
        {
            if (heldFuel - 5 < 0)
                heldFuel = 0;
            else
                heldFuel -= 5;

            fuelBar.SetFuel(heldFuel);

        }

    }

    void OnCollisionStay2D(Collision2D hitInfo)
    {

        if (hitInfo.gameObject.name == "CrabEnemy(Clone)" && isHurt == false)
        {
            isHurt = true;
            animator.SetBool("IsHurt", isHurt);
            ScoreScript.lives = ScoreScript.lives - 1;
            lives--;
            gameObject.layer = LayerMask.NameToLayer("Ghost");  
        }
    

    }


}
