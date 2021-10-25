using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //holds whatever object that you want to spawn
    public GameObject entityHolder;

    //holds the spawner drag spawner into here
    public GameObject spawner;

    //changes how long it takes between each spawn
    public float spawnTimer = 5.0f;
    private float timer;

    private bool pause;

    void Update()
    {
        //An attempt to make timer pause (didn't work)
/*        if (Input.GetKey(KeyCode.F9))
        {
            //toggle timeScale so in edit mode timer pauses
            pause = true;

            if (pause)
            {
                if (Input.GetKey(KeyCode.F9))
                {
                    pause = false;
                }
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }*/
        
        // internal counter
        timer += Time.deltaTime;
        if (timer > spawnTimer)
        {
            //Resets timer once it hits the spawnTimer
            timer = 0.0f;

            
            //Spawns object once timer reaches spawnTimer
            GameObject newObject = (GameObject)Instantiate(entityHolder, transform.position, Quaternion.identity) as GameObject;
        }
    }
}
