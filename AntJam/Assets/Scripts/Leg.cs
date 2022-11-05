using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Rendering;



public class Leg : MonoBehaviour
{
    public const int IDLE = 0;
    public const int STOMP = 1;

    [SerializeField] GameEngine game;
    [SerializeField] SpriteRenderer legimg;
    [SerializeField] SpriteRenderer shadow;
    [SerializeField] float speed;
    [SerializeField] float speedMax;
    private int state = IDLE;

    void Start()
    {
        
    }

    void Update()
    {
        if (state == IDLE)
        {
            Vector3 target = getMousePos();
            //move leg
            float del = Mathf.Clamp(Time.deltaTime * speed * (target.x - transform.position.x), -speedMax, speedMax);
            Vector3 move = transform.position + new Vector3(del, 0, 0);
            transform.position = move;
            //move shadow up/down
            del = Mathf.Clamp(Time.deltaTime * speed * (target.y - shadow.transform.position.y), -speedMax, speedMax);
            move = shadow.transform.position + new Vector3(0, del, 0);
            shadow.transform.position = move;

            //check if should stomp
        }
        else if (state == STOMP)
        {

        }
    }
    Vector3 getMousePos()
    {
        Vector3 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cam.z = transform.position.z;
        return cam;
    }
}
