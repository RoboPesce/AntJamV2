using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Rendering;



public class Leg : MonoBehaviour
{
    private const int IDLE = 0;
    private const int STOMP = 1;
    private const int ONGROUND = 2;
    private const int LIFT = 3;

    [SerializeField] GameManager game;
    [SerializeField] SpriteRenderer legimg;
    [SerializeField] SpriteRenderer shadow;
    [SerializeField] float speed;
    [SerializeField] float speedMax;
    [SerializeField] float downSpeed;
    [SerializeField] float upSpeed;
    [SerializeField] float[] stompTime = { 2.5f, 5f };
    float stompTimer;
    float groundTime = 1f;
    float groundTimer;
    private int state = IDLE;

    void Start()
    {
        resetStompTimer();
        groundTimer = groundTime;
    }

    void Update()
    {
        Debug.Log("leg state: " + state);

        switch (state)
        {
            case IDLE:
                Vector3 target = getMousePos();
                //move leg
                float del = Mathf.Clamp(Time.deltaTime * speed * (target.x - transform.position.x), -speedMax, speedMax);
                Vector3 move = transform.position + new Vector3(del, 0, 0);
                transform.position = move;
                //move shadow up/down
                del = Mathf.Clamp(Time.deltaTime * speed * (target.y - shadow.transform.position.y), -speedMax, speedMax);
                move = shadow.transform.position + new Vector3(0, del, 0);
                move.y = Mathf.Clamp(move.y, -5 + shadow.transform.localScale.y/2, 3 - shadow.transform.localScale.y / 2);
                shadow.transform.position = move;
                stompTimer -= Time.deltaTime;
                if (stompTimer <= 0) state = STOMP;
                break;
            case STOMP:
                float legSpeed = downSpeed * Time.deltaTime * (-shadow.transform.position.y / 2);
                Vector3 legPos = legimg.transform.position;
                legPos.y = Mathf.Clamp(legPos.y - legSpeed, shadow.transform.position.y + 5, 9);
                legimg.transform.position = legPos;
                if (legPos.y == shadow.transform.position.y + 5)
                {
                    groundTimer = groundTime;
                    state = ONGROUND;
                }
                break;
            case ONGROUND:
                groundTimer -= Time.deltaTime;
                if (groundTimer <= 0) state = LIFT;
                break;
            case LIFT:
                legSpeed = upSpeed * Time.deltaTime * (-shadow.transform.position.y / 2);
                legPos = legimg.transform.position;
                legPos.y = Mathf.Clamp(legPos.y + legSpeed, shadow.transform.position.y + 5, 9);
                legimg.transform.position = legPos;
                if (legPos.y == 9)
                {
                    resetStompTimer();
                    state = IDLE;
                }
                break;
        }
    }
    Vector3 getMousePos()
    {
        Vector3 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cam.z = transform.position.z;
        return cam;
    }

    void resetStompTimer()
    {
        state = IDLE;

        int score = game.getScore();
        float time = Random.Range(stompTime[0], stompTime[1]);
        //Finish implementing!!!!
        stompTimer = time;
    }
}
