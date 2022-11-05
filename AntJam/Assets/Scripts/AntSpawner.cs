using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject myAnt;
    private float timer;
    private float spawnTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
        //Instantiate(myAnt, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    void SpawnAnt()
    {
        if(timer <= 0.0f){
            Instantiate(myAnt, gameObject.transform);
            timer = spawnTime;
        }
        
    }
}

