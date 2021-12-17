using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class SingleBulletScript : MonoBehaviour
{
    [DllImport("DLLForEnginesExam")]
    private static extern float GetLife();
    float timer = 0.0f;
    float lifespan = GetLife();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>lifespan)
        {
            gameObject.SetActive(false);
            timer = 0.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
