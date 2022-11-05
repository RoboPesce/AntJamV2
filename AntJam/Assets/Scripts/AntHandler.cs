using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntHandler : MonoBehaviour
{
    //[SerializeField] AntSpawner mySpawner;
    private AntSpawner mySpawner;
    private int antNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        mySpawner = GameObject.FindObjectOfType<AntSpawner>();
        mySpawner.SpawnAnt();
        antNumber += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(EatFood()){
            mySpawner.SpawnAnt();
            antNumber += 1;
        }
    }
    bool EatFood(){
        return true;
    }
}
