using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject food;
    private float foodTimer;
    [SerializeField] GameManager game;
    [SerializeField] private float spawnTime = 5.0f;
    private float minX = -10.0f;
    private float maxX = 10.0f;
    private float maxY = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        foodTimer = spawnTime;   
    }

    // Update is called once per frame
    void Update()
    {
        foodTimer -= Time.deltaTime;
        if(foodTimer <= 0.0f){
            float x = Random.Range(minX, maxX);
            transform.position = new Vector3(x, maxY, 0.0f);
            SpawnFood();
            spawnTime = Random.Range(1.0f, 6.0f);
            foodTimer = spawnTime;
        }
    }
    void SpawnFood()
    {
        GameObject a = Instantiate(food, gameObject.transform);
        a.transform.parent = game.transform;
    }
}
