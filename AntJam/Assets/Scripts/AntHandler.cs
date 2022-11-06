using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AntHandler : MonoBehaviour
{
    [SerializeField] private AntSpawner mySpawner;
    [SerializeField] private int maxAnts = 100;
    [SerializeField] AudioManager audioManager;
    bool threshold = false;
    float endgameTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //mySpawner = GameObject.FindObjectOfType<AntSpawner>();
        //mySpawner.SpawnAnt();
        //mySpawner.SpawnAnt();
        audioManager.Play("AntMusic");
    }

    // Update is called once per frame
    void Update()
    {
        if (getAntCount() == 0)
        {
            endgameTimer -= Time.deltaTime;
            if (endgameTimer <= 0) SceneManager.LoadScene(0);
        }
    }
    public int getAntCount()
    {
        int c = transform.childCount - 1;
        return c;
    }

    public void SpawnAnAnt(){
        if(getAntCount() < maxAnts){
            mySpawner.SpawnAnt();
        }
        if(getAntCount() > 10 && !threshold){
            audioManager.StopPlaying("AntMusic");
            audioManager.Play("AntMusicFast");
            threshold = true;
        }
    }
}
