using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarScript : MonoBehaviour
{
    public Slider slide;
    public Gradient gradient;
    public Image fill;
    public void SetFuel(float h)
    {
        slide.value = h;
        fill.color = gradient.Evaluate(slide.normalizedValue);
    }
    // Start is called before the first frame update
    void Start()
    {
 
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
