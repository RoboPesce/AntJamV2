using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour
{
    private Vector3 movement;
    [SerializeField] private float antSpeed=2.0f;
    [SerializeField] public CapsuleCollider2D myCollider;
    private float timer = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Camera.main.ScreenToWorldPoint(Input.mousePosition);
        setMovement();
        myCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer <= 0.0f){
            myCollider.enabled = true;
        }
        setMovement();
        //rotation
        Vector3 forward = getForward();
        float dist = Vector3.Distance(transform.position, getMousePos());
        float angle = Vector2.SignedAngle(forward, movement);
        //check if ant is pointing towards player
        if (angle != 0) transform.Rotate(0.0f, 0.0f, angle);

        movement *= Time.deltaTime * antSpeed;
        /*
        RaycastHit2D hit = Physics2D.Raycast((Vector2) transform.position, (Vector2) forward, 1);
        float clamp = Mathf.Infinity;
        if (hit.transform != null) clamp = Vector3.Distance(transform.position, hit.transform.position);
        movement *= Mathf.Clamp(movement.magnitude, 0, clamp);
        Debug.Log(movement.magnitude);
        */
        if(dist > 1.0f ) transform.position += movement;
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

    private void OnColliderEnter2D(Collider2D col){

    }
}