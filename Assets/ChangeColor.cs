using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Light lt;
    

    // Start is called before the first frame update
    void Start()
    {
        
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Color bruh = new Color(0.5f, 1f, 1f, 1f);
        lt.color = (bruh);
    }
}
