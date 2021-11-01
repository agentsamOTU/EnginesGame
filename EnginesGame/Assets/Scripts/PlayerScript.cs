using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public GameObject bulletHolder;
    private Rigidbody body;

    public float fireTime=0.0f;

    public float fireDelay = 0.01f;
    private Vector3 moveMe;
    public int tickToMove = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fireTime += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && fireTime > fireDelay)
        {
            bulletHolder.GetComponent<BulletsScript>().Fire(transform.forward, transform.position);
            fireTime = 0.0f;
        }
    }

    void FixedUpdate()
    {
        float tempVert = Input.GetAxis("Vertical");
        float tempHor = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(tempHor * speed, 0.0f, tempVert * speed);
        if (tickToMove != 0)
        {
            tickToMove -= 1;
        }
        else
        {
            body.velocity = dir;
        }
        if (tempHor != 0 || tempVert != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(tempHor, 0.0f, tempVert), Vector3.up);

        }

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GlobalVariableScript.Instance.playerHealth--;
            moveMe = collision.transform.position - transform.position;

            //body.velocity = new Vector3(moveMe.x,0.0f,moveMe.z)*3.0f;
            tickToMove = 20;
            //transform.position = transform.position + moveMe * 2.0f;
            if (GlobalVariableScript.Instance.playerHealth <= 0)
            {
                Application.Quit();
            }
        }
    }
}
