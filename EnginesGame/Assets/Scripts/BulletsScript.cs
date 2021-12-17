using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BulletsScript :MonoBehaviour
{
    
    public List<GameObject> bullets;

    private int bullNumber = 0;
    // Start is called before the first frame update
    public void Start()
    {
        bullets[0].SetActive(false);
    }

    public void Fire(Vector3 dir,Vector3 pos)
    {
      
      if(bullets[bullNumber].activeInHierarchy)
      {
            bullNumber++;
            bullets.Insert(bullNumber,GameObject.Instantiate(bullets[0]));
            if (bullNumber >= bullets.Count)
            {
                bullNumber = 0;
            }
        }
        bullets[bullNumber].SetActive(true);
        bullets[bullNumber].GetComponent<AudioSource>().Play();
        bullets[bullNumber].GetComponent<Rigidbody>().velocity = dir * 20.0f;
        bullets[bullNumber].transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        bullets[bullNumber].transform.position = Vector3.Normalize(dir) * 2.0f + pos + new Vector3(0.0f, 0.5f, 0.0f);
        bullNumber++;

        if (bullNumber >= bullets.Count)
        {
            bullNumber = 0;
        }
    }
}
