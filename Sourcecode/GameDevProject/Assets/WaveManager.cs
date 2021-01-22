using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private float crabTimer = 0f;
    private float octoTimer = 0f;
    private float fuelTimer = 0f;


    public GameObject crabPreFab;
    public GameObject octoPreFab;
    public GameObject fuelPreFab;


    public Transform fuelSpawn0;
    public Transform fuelSpawn1;
    public Transform fuelSpawn2;
    public Transform fuelSpawn3;
    public Transform fuelSpawn4;
    public Transform fuelSpawn5;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.shipsFuel = 0;
        PlayerStats.seconds = 0;
        PlayerStats.minutes = 0;
        Instantiate(crabPreFab, new Vector3(-100,-100,-100), Quaternion.identity);
        Instantiate(crabPreFab, new Vector3(-100, -100, -100), Quaternion.identity);
        InstFuel();
    }

    void InstFuel()
    {
        int pos = Random.Range(0, 6);
        Vector3 newPos = new Vector3(0,0,0);
        switch (pos)
        {
            case (0): newPos = fuelSpawn0.position; break;
            case (1): newPos = fuelSpawn1.position; break;
            case (2): newPos = fuelSpawn2.position; break;
            case (3): newPos = fuelSpawn3.position; break;
            case (4): newPos = fuelSpawn4.position; break;
            case (5): newPos = fuelSpawn5.position; break;
        }
        
        Instantiate(fuelPreFab, newPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        crabTimer += Time.deltaTime;
        octoTimer += Time.deltaTime;
        fuelTimer += Time.deltaTime;

        if (crabTimer > 8)
        {
            crabTimer = 0;
            Instantiate(crabPreFab, new Vector3(-100, -100, -100), Quaternion.identity);
            Instantiate(crabPreFab, new Vector3(-100, -100, -100), Quaternion.identity);
        }

        if (octoTimer > 8)
        {
            octoTimer = 0;
            Instantiate(octoPreFab, new Vector3(-100, -100, -100), Quaternion.identity);
        }

        if (fuelTimer > 8)
        {
            InstFuel();
            fuelTimer = 0;

        }
    }
}
