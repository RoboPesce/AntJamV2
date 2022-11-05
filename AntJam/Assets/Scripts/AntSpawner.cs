using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject myAnt;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(myAnt, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1.0f){
            Instantiate(myAnt, gameObject.transform);
            timer = 0.0f;
        }
    }
}

