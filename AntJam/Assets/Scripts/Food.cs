using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private const int FALL = 0;
    private const int FRESH = 1;
    private const int ROT = 2;
    private int myState;
    private const float maxY = 2.5f;
    private const float minY = -4.5f;
    private const float fallSpeed = -2.0f;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        myState = FALL;
        float y = Random.Range(minY, maxY);
        targetPosition = new Vector3(transform.position.x, y, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(myState == FALL){
            float y = transform.position.y;
            y += fallSpeed*Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, 0.0f);
            Vector3 myPos = transform.position;
            if(Vector3.Distance(myPos, targetPosition) <= 0.1f){
                transform.position= targetPosition;
                myState = FRESH;
            }
        }
        else if(myState == FRESH){

        }
        else if(myState == ROT){

        }
    }
}
