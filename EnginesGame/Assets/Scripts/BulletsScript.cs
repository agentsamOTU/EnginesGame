using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsScript :MonoBehaviour
{
    public GameObject[] bullets;

    private int bullNumber = 0;
    // Start is called before the first frame update

    public void Fire(Vector3 dir,Vector3 pos)
    {
        bullets[bullNumber].GetComponent<AudioSource>().Play();
        bullets[bullNumber].GetComponent<Rigidbody>().velocity = dir*10.0f;
        bullets[bullNumber].transform.rotation = Quaternion.LookRotation(dir,Vector3.up);
        bullets[bullNumber].transform.position = Vector3.Normalize(dir) * 2.0f + pos + new Vector3(0.0f, 0.5f, 0.0f);
        bullNumber++;
        if (bullNumber > 9)
        {
            bullNumber = 0;
        }
    }
}
