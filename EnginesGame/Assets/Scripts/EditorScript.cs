using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorScript : MonoBehaviour
{
    public GameObject[] Placeables;
    GameObject selectedObj;
    public Stack objectQueue;
    public Cinemachine.CinemachineVirtualCamera vCam;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<Placeables.Length;i++)
        {
            Placeables[i] = GameObject.Instantiate(Placeables[i], transform.position, Quaternion.identity);
            Placeables[i].SetActive(false);
        }
        //selectedObj = GameObject.Instantiate(Placeables[GlobalVariableScript.Instance.selectedObject], transform.position, Quaternion.identity);
        selectedObj = Placeables[GlobalVariableScript.Instance.selectedObject];
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVariableScript.Instance.inEditor)
        {
            selectedObj.SetActive(true);
            selectedObj.transform.position = transform.position;
            if (Input.GetKeyDown(KeyCode.O))
            {
                selectedObj.SetActive(false);

                GlobalVariableScript.Instance.selectedObject -= 1;
                if (GlobalVariableScript.Instance.selectedObject < 0)
                    GlobalVariableScript.Instance.selectedObject = Placeables.Length - 1;
                //selectedObj = GameObject.Instantiate(Placeables[GlobalVariableScript.Instance.selectedObject], transform.position, Quaternion.identity);
                selectedObj = Placeables[GlobalVariableScript.Instance.selectedObject];
                selectedObj.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.P))
            {
                selectedObj.SetActive(false);

                GlobalVariableScript.Instance.selectedObject += 1;
                if (GlobalVariableScript.Instance.selectedObject >= Placeables.Length)
                    GlobalVariableScript.Instance.selectedObject = 0;
                //selectedObj = GameObject.Instantiate(Placeables[GlobalVariableScript.Instance.selectedObject], transform.position, Quaternion.identity);
                selectedObj = Placeables[GlobalVariableScript.Instance.selectedObject];
                selectedObj.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                selectedObj.transform.rotation *= Quaternion.Euler(0.0f, 45.0f, 0.0f);
            }    
            if(Input.GetKeyDown(KeyCode.Return))
            {
                ICommand command;
                command = new PlaceObjectCommand(selectedObj,selectedObj.transform.position,selectedObj.transform.rotation);
                CommandInvoker.AddCommand(command);
                //selectedObj = GameObject.Instantiate(Placeables[GlobalVariableScript.Instance.selectedObject], transform.position, Quaternion.identity);
                selectedObj = Placeables[GlobalVariableScript.Instance.selectedObject];
            }        
            if(Input.GetKeyDown(KeyCode.Comma))
            {
                
            }
        }
        else
        {
            selectedObj.SetActive(false);
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
