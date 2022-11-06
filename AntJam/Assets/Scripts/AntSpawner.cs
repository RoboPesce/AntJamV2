using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    [SerializeField] GameEngine game;
    [SerializeField] AntHandler antHandler;
    public GameObject myAnt;
    private float timer;
    private float spawnTime = 5.0f;
    private float minX = -11.0f;
    private float maxX = 11.0f;
    private float maxY = 2.5f;
    private float minY = -5.0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
        transform.position = new Vector3(3.0f, 0.0f, 0.0f);
        GameObject a = Instantiate(myAnt, gameObject.transform);
        a.transform.parent = antHandler.transform;

        //Instantiate(myAnt, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //SpawnAnt();
    }

    public void SpawnAnt()
    {
        if (timer <= 0.0f)
        {
            int randNum = Random.Range(0, 3);
            transform.position = GetPosition(randNum);
            GameObject a = Instantiate(myAnt, gameObject.transform);
            a.transform.parent = antHandler.transform;
            randNum = Random.Range(0, 3);
            transform.position = GetPosition(randNum);
            GameObject b = Instantiate(myAnt, gameObject.transform);
            b.transform.parent = antHandler.transform;
            timer = spawnTime;
        }
    }

    Vector3 GetPosition(int num)
    {
        float x = 0.0f;
        float y = 0.0f;
        if(num == 0){//chooses position on the left of the screen
            x = minX -.5f;
            y = Random.Range(minY, maxY);
        }
        else if(num == 1){//chooses position on the right of the screen
            x = maxX + .5f;
            y = Random.Range(minY, maxY);
        }
        else{//chooses position on the bottom of the screen
            x = Random.Range(minX, maxX);
            y = minY - .5f;
        }
        return new Vector3(x, y, 0.0f);
    }
}

