using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static int lives = 5;
    Text lives_value;

    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
        lives_value = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lives_value.text = "Lives: " + lives; 
    }
}
