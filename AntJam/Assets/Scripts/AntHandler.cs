using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntHandler : MonoBehaviour
{
    [SerializeField] private AntSpawner mySpawner;
    [SerializeField] private int maxAnts = 5;
    // Start is called before the first frame update
    void Start()
    {
        //mySpawner = GameObject.FindObjectOfType<AntSpawner>();
        mySpawner.SpawnAnt();
    }

    // Update is called once per frame
    void Update()
    {

        if(getAntCount() < maxAnts && EatFood()){
            mySpawner.SpawnAnt();
        }
    }
    bool EatFood(){
        return true;
    }

    public int getAntCount()
    {
        int c = transform.childCount - 1;
        return c;
    }
}
