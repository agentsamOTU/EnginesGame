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
        if (!GlobalVariableScript.Instance.inEditor)
        {
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
}
