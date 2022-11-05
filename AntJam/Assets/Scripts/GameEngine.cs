using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    [SerializeField] SpriteRenderer floor;
    [SerializeField] Leg leg;
    [SerializeField] AntSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        setLegBound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLegBound()
    {
        leg.setBound(floor.transform.localScale.x / 2);
    }
}
