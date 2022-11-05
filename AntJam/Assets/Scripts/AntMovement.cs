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
        setMovement();
        //rotation
        float dist = Vector3.Distance(transform.position, getMousePos());
        float angle = Vector2.SignedAngle(getForward(), movement);
        Debug.Log("Euler:"+transform.eulerAngles.z);
        Debug.Log("angle:" + angle);
        //check if ant is pointing towards player
        if (angle != 0) transform.Rotate(0.0f, 0.0f, angle);
        
        if(dist > 1.0f ) transform.position += Time.deltaTime*movement*antSpeed;
    }

    Vector3 getMousePos()
    {
        Vector3 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cam.z = transform.position.z;
        return cam;
    }

    Vector3 getForward()
    {
        float rads = transform.eulerAngles.z * Mathf.PI / 180f;
        return new Vector3(Mathf.Cos(rads), Mathf.Sin(rads), transform.position.z);
    }

    void setMovement()
    {
        Vector3 m = getMousePos() - transform.position;
        m.z = transform.position.z;
        movement = m;
        movement.Normalize();
    }
}