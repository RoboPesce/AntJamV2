using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] GameObject shadow;
    private AntHandler myHandler;
    private GameObject myShadow;
    private GameManager game;
    private const int FALL = 0;
    private const int FRESH = 1;
    private const int ROT = 2;
    private int myState;
    private const float maxY = 2.5f;
    private const float minY = -4.5f;
    private const float fallSpeed = -2.0f;
    private Vector3 targetPosition;
    private float freshTimer;
    private float freshTime = 5.0f;
    private float rotTimer;
    private float rotTime = 5.0f;
    private SpriteRenderer shadowRender;

    // Start is called before the first frame update
    void Start()
    {
        myState = FALL;
        freshTimer = freshTime;
        rotTimer = rotTime;
        float y = Random.Range(minY, maxY);
        targetPosition = new Vector3(transform.position.x, y, 0.0f);
        myShadow = Instantiate(shadow, targetPosition - new Vector3(0.0f, 0.25f, 0.0f), Quaternion.identity);
        shadowRender = myShadow.GetComponent<SpriteRenderer>();
        game = GameObject.FindObjectOfType<GameManager>();
        myShadow.transform.parent = game.transform;
        myHandler = GameObject.FindObjectOfType<AntHandler>();
        shadowRender.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if(myState == FALL){
            Color newColor = shadowRender.color;
            newColor.r -= .1f*Time.deltaTime;
            newColor.g -= .1f*Time.deltaTime;
            newColor.b -= .1f*Time.deltaTime;
            shadowRender.color = newColor;
            float y = transform.position.y;
            y += fallSpeed*Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, 0.0f);
            Vector3 myPos = transform.position;
            if(Vector3.Distance(myPos, targetPosition) <= 0.1f){
                transform.position= targetPosition;
                myState = FRESH;
                Destroy(myShadow);
            }
        }
        else if(myState == FRESH){
            freshTimer -= Time.deltaTime;
            if(freshTimer <= 0.0f){
                myState = ROT;
            }
        }
        else if(myState == ROT){
            rotTimer -= Time.deltaTime;
            if(rotTimer <= 0.0f){
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col){
        Debug.Log("Trigger");
        if(myState == FRESH){
            myHandler.SpawnAnAnt();
            Destroy(gameObject);
        }
        else if(myState == ROT){
            Destroy(col.gameObject);
        }
    }
}
