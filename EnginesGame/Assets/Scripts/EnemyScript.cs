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

    private NavMeshAgent nav;

    public GameObject player;

    public float followDist = 20.0f;
    public int health = 2;

    public float waitOnTouch = 1.0f;

    private float timeSinceTouch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = gameObject.GetComponent<NavMeshAgent>();
        nav.speed = GetEnemySpeed();
        Debug.Log(nav.speed);
        Debug.Log(GetEnemySpeed());
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalVariableScript.Instance.inEditor)
        {
            timeSinceTouch += Time.deltaTime;
            if (timeSinceTouch > waitOnTouch)
            {
                nav.isStopped = false;
            }
            if (Vector3.Magnitude(player.transform.position - transform.position) < followDist)
            {
                nav.SetDestination(player.transform.position);
            }
        }
        else
        {
            nav.isStopped = false;
            nav.SetDestination(gameObject.transform.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            transform.position = transform.position - new Vector3(0.0f, 2.0f, 0.0f);
            health--;
            if (health <= 0)
            {
                Object.Destroy(gameObject);
            }
        }

        if(collision.gameObject.tag=="Player")
        {
            nav.isStopped = true;
            timeSinceTouch = 0.0f;

        }

    }
}
