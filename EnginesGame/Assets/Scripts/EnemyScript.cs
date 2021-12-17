using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [DllImport("EnginesGameDLL")]
    private static extern float GetEnemySpeed();

    public EnemiesScript parent;
    
    public int health = 1;

    // Start is called before the first frame update
    void Start()
    {
       
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            transform.position = transform.position - new Vector3(0.0f, 2.0f, 0.0f);
            health--;
            if (health <= 0)
            {
                parent.Kill();
                Object.Destroy(gameObject);
            }
        }

        if(collision.gameObject.tag=="Player")
        {
            

        }

    }
}
