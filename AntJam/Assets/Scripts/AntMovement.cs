using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour
{
    private Vector3 movement;
    [SerializeField] private float antSpeed=2.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Camera.main.ScreenToWorldPoint(Input.mousePosition);
        setMovement();
    }

    // Update is called once per frame
    void Update()
    {
        //rotation 
        float dist = Vector3.Distance(transform.position, getMousePos());
        float angle = Vector2.Angle(getForward(), movement);
        Debug.DrawRay(transform.position, getForward(), new Color(0, 0, 0));
        Debug.Log("Euler:"+transform.eulerAngles.z);
        Debug.Log("angle:" + angle);
        if(angle != 0)//check if ant is pointing towards player
        { 
            transform.Rotate(0.0f, 0.0f, 1f);
        }
        
        if(dist > 1.0f )//if ant is within a certain radius
        {
            setMovement();
            transform.position += Time.deltaTime*movement*antSpeed;
        }
        
    }

    Vector3 getMousePos()
    {
        Vector3 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cam.z = transform.position.z;
        return cam;
    }

    Vector3 getForward()
    {
        return new Vector3(Mathf.Cos(transform.eulerAngles.z), Mathf.Sin(transform.eulerAngles.z), transform.position.z);
    }

    void setMovement()
    {
        Vector3 m = getMousePos() - transform.position;
        m.z = transform.position.z;
        movement = m;
        movement.Normalize();
    }
}