using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationFinished(int isFinished)
    {
        if (isFinished == 1)
            Destroy(gameObject);
    }
}
