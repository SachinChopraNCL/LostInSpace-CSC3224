using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelScript : MonoBehaviour
{
    public static float fuel = 0;
    Text fuel_value; 

    // Start is called before the first frame update
    void Start()
    {
        fuel_value = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        fuel_value.text = "Fuel Value: " + fuel;
    }
}
