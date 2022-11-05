using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour
{
    private Vector3 movement;
    private float antSpeed;
    private Vector3 forward;
    // Start is called before the first frame update
    void Start()
    {
        //Camera.main.ScreenToWorldPoint(Input.mousePosition);
        movement = getMousePos()  - transform.position;
        forward = new Vector3(0.0f, 1.0f, 0.0f);
        //movement.Normalize();
        antSpeed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //rotation 
        float dist = Vector3.Distance(transform.position, getMousePos() );
        float angle = Vector3.Angle(forward, movement);
        //Debug.Log(Vector3.Dot(forward, movement));
        Debug.Log("Euler:"+transform.eulerAngles.z);
        if(Vector3.Dot(forward, movement) != 0)//check if ant is pointing towards player
        { 
            transform.Rotate(0.0f, 0.0f, angle*Time.deltaTime);
        }
        
        if(dist > 1.0f )//if ant is within a certain radius
        {
            movement = getMousePos() - transform.position;
            movement.Normalize();
            transform.position += Time.deltaTime*movement*antSpeed;
        }
        
    }

    Vector3 getMousePos()
    {
        Vector3 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cam.z = transform.position.z;
        return cam;
    }
}