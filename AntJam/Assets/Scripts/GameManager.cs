using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AntHandler myHandler;
    private int score = 0;
    private float timer = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0.0f){
            score += 10 * myHandler.getAntCount();
            timer = 1.0f;
            Debug.Log(score);
        }
    }
}
