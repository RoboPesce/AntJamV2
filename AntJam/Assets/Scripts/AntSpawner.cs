using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject myAnt;
    private float timer;
    private float spawnTime = 5.0f;
    private float minX = -11.0f;
    private float maxX = 11.0f;
    private float maxY = 2.5f;
    private float minY = -2.5f;
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
            int randNum = Random.Range(0,3);
            transform.position = GetPosition(randNum);
            Instantiate(myAnt, gameObject.transform);
            timer = spawnTime;
        }
        
    }

    Vector3 GetPosition(int num)
    {
        if(num == 0){//chooses position on the left of the screen

        }
        else if(num == 1){//chooses position on the bottom of the screen

        }
        else{//chooses position on the right of the screen

        }
        return Vector3.zero;
    }
}

