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
    private float rotTimer;
    private SpriteRenderer shadowRender;
    private Vector3 scaleChange;
    [SerializeField] Sprite appleFresh;
    [SerializeField] Sprite appleRot;
    [SerializeField] Sprite breadFresh;
    [SerializeField] Sprite breadRot;
    [SerializeField] Sprite cheeseFresh;
    [SerializeField] Sprite cheeseRot;
    [SerializeField] Sprite cupcakeFresh;
    [SerializeField] Sprite cupcakeRot;
    [SerializeField] Sprite grapesFresh;
    [SerializeField] Sprite grapesRot;
    [SerializeField] public AudioManager audioManager;
    private Sprite myFresh;
    private Sprite myRot;
    private int antsKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        myState = FALL;
        freshTimer = Random.Range(1.0f, 5.0f);
        rotTimer = 10.0f;
        float y = Random.Range(minY, maxY);
        targetPosition = new Vector3(transform.position.x, y, 0.0f);
        myShadow = Instantiate(shadow, targetPosition - new Vector3(0.0f, 0.25f, 0.0f), Quaternion.identity);
        shadowRender = myShadow.GetComponent<SpriteRenderer>();
        game = GameObject.FindObjectOfType<GameManager>();
        myShadow.transform.parent = game.transform;
        myHandler = GameObject.FindObjectOfType<AntHandler>();
        shadowRender.color = new Color(0.0f, 0.0f, 0.0f, .1f);
        scaleChange = new Vector3(-0.1f, -0.1f, 0.0f);

        int num = Random.Range(0,5);
        if(num == 0){
            myFresh = appleFresh;
            myRot = appleRot;
        }
        else if(num == 1){
            myFresh = breadFresh;
            myRot = breadRot;
        }
        else if(num == 2){
            myFresh = cheeseFresh;
            myRot = cheeseRot;
        }
        else if(num == 3){
            myFresh = cupcakeFresh;
            myRot = cupcakeRot;
        }
        else{
            myFresh = grapesFresh;
            myRot = grapesRot;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = myFresh;

    }

    // Update is called once per frame
    void Update()
    {
        if(myState == FALL){
            Color newColor = shadowRender.color;
            newColor.a += .1f*Time.deltaTime;
            shadowRender.color = newColor;
            myShadow.transform.localScale += scaleChange*Time.deltaTime;
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
                gameObject.GetComponent<SpriteRenderer>().sprite = myRot;
            }
        }
        else if(myState == ROT){
            
        }
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(myState == FRESH){
            //BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
            //myCollider.enabled = false;
            myHandler.SpawnAnAnt();
            Destroy(gameObject);
        }
        else if(myState == ROT){
            audioManager = GameObject.FindObjectOfType<AudioManager>();
            audioManager.Play("AntDeath");
            antsKilled += 1;
            Destroy(col.gameObject);
            if(antsKilled >= 5){
                Destroy(gameObject);
            }
        }
    }
}
