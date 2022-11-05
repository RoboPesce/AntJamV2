using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

enum States
{
    IDLE, //0
    STOMP //1
}

public class Leg : MonoBehaviour
{
    private int state = 0;
    private float sidebound; // +/- the "radius" to the side

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
