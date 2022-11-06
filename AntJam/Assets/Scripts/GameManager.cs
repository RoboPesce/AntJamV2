using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] AntHandler myHandler;
    [SerializeField] Text myText;
    [SerializeField] Text antText;
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
        myText.text = "Score: "+score.ToString();
        antText.text = "Ants: "+myHandler.getAntCount();
        if(timer <= 0.0f){
            score += 10 * myHandler.getAntCount();
            timer = 1.0f;
        }
    }
}
