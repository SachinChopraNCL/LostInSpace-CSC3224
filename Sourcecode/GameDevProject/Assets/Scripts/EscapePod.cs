using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapePod : MonoBehaviour
{

    public float maxFuel = 10000;
    public float currentFuel = 0;
    public FuelBarScript fuelBar;

    // Start is called before the first frame update
    void Start()
    {
        currentFuel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnCollisionStay2D(Collision2D hitInfo) 
    {
        Debug.Log("Refuelling!");

        if (hitInfo.gameObject.name == "Player" && Input.GetButtonDown("PickUp"))
        {
            SoundManager.PlaySound("refuel");
            GameObject player = hitInfo.gameObject;
            PlayerBehaviour playerScript = player.GetComponent<PlayerBehaviour>();
            currentFuel += playerScript.heldFuel;
            if (currentFuel >= 10000)
            {
                SceneManager.LoadScene("You_Win");
            }
            playerScript.heldFuel = 0;
            fuelBar.SetFuel(currentFuel);
            playerScript.fuelBar.SetFuel(0);
            PlayerStats.shipsFuel = currentFuel;

        }

    }
}
