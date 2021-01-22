using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeldFuelScript : MonoBehaviour
{
    Text fuel_value;

    // Start is called before the first frame update
    void Start()
    {
        fuel_value = GetComponent<Text>();
        fuel_value.text = "Ship's Fuel: " + PlayerStats.shipsFuel;

    }

}
