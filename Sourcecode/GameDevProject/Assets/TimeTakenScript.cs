using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTakenScript : MonoBehaviour
{
    Text time_value;

    // Start is called before the first frame update
    void Start()
    {
        time_value = GetComponent<Text>();
        time_value.text = "Time Taken:  " + PlayerStats.minutes.ToString("00") + ":" + PlayerStats.seconds.ToString("00");

    }

}

