using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorScript : MonoBehaviour
{
    public GameObject[] Placeables;
    GameObject selectedObj;
    public Stack objectQueue;
    int objectCounter = 0;
    public Cinemachine.CinemachineVirtualCamera vCam;

    // Start is called before the first frame update
    void Start()
    {
        selectedObj = GameObject.Instantiate(Placeables[objectCounter], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVariableScript.Instance.inEditor)
        {
            selectedObj.transform.position = transform.position;
            if (Input.GetKeyDown(KeyCode.O))
            {
                GameObject.Destroy(selectedObj);

                objectCounter -= 1;
                if (objectCounter < 0)
                    objectCounter = Placeables.Length - 1;
                selectedObj = GameObject.Instantiate(Placeables[objectCounter], transform.position, Quaternion.identity);
            }
            if(Input.GetKeyDown(KeyCode.P))
            {
                GameObject.Destroy(selectedObj);

                objectCounter += 1;
                if (objectCounter >= Placeables.Length)
                    objectCounter = 0;
                selectedObj = GameObject.Instantiate(Placeables[objectCounter], transform.position, Quaternion.identity);
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                selectedObj.transform.rotation *= Quaternion.Euler(0.0f, 45.0f, 0.0f);
            }    
            if(Input.GetKeyDown(KeyCode.Return))
            {
                selectedObj = GameObject.Instantiate(Placeables[objectCounter], transform.position, Quaternion.identity);
            }
        }        
    }

    private void FixedUpdate()
    {
        if (GlobalVariableScript.Instance.inEditor)
        {
            vCam.m_Follow = gameObject.transform;

            transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }
        
    }
}
