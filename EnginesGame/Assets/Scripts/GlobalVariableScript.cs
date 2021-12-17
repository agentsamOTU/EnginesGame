using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static GlobalVariableScript Instance;

    public int playerHealth = 3;

    public int enemyDestroyed = 0;

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
