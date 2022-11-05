using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Rendering;

enum States
{
    IDLE, //0
    STOMP //1
}

public class Leg : MonoBehaviour
{
    [SerializeField] GameEngine game;
    [SerializeField] SpriteRenderer legimg;
    [SerializeField] SpriteRenderer shadow;
    private int state = 0;
    private float sidebound; // +/- the "radius" to the side

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void setBound(float x) { sidebound = x; }
}
