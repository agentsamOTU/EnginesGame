using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static GlobalVariableScript Instance;

    public int playerHealth = 10;

    public bool inEditor = false;

    public int selectedObject = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
