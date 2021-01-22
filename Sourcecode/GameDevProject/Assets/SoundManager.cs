using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip pickUp;
    public static AudioClip enemyDeath;
    public static AudioClip fuelShip;
    public static AudioClip sentryShot;
    public static AudioClip hurtSound;
    public static AudioClip playerLose;
    public static AudioClip jumpNoise;
    public static AudioClip healthNoise;

    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        pickUp = Resources.Load<AudioClip>("pickup");
        enemyDeath = Resources.Load<AudioClip>("death");
        fuelShip = Resources.Load<AudioClip>("refuel");
        sentryShot = Resources.Load<AudioClip>("sentryShot");
        hurtSound = Resources.Load<AudioClip>("hurt");
        playerLose = Resources.Load<AudioClip>("playerDeath");
        jumpNoise = Resources.Load<AudioClip>("jump");
        healthNoise = Resources.Load<AudioClip>("health");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) {
        switch (clip)
        {
            case "death":
                audioSrc.PlayOneShot(enemyDeath);
                break;
            case "pickup":
                audioSrc.PlayOneShot(pickUp);
                break;
            case "refuel":
                audioSrc.PlayOneShot(fuelShip);
                break;
            case "sentryshot":
                audioSrc.PlayOneShot(sentryShot);
                break;
            case "hurt":
                audioSrc.PlayOneShot(hurtSound);
                break;
            case "player":
                audioSrc.PlayOneShot(playerLose);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpNoise);
                break;
            case "health":
                audioSrc.PlayOneShot(healthNoise);
                break;
        }
    }
}
