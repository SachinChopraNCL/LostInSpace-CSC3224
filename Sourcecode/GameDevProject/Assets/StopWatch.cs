using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    float timer;
    float seconds;
    float minutes;

    [SerializeField] Text stopWatchText;
  
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = timer % 60;
        minutes = timer / 60;

        PlayerStats.minutes = minutes;
        PlayerStats.seconds = seconds;

        stopWatchText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
