using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Text loseText;
    public Text healthText;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text ="Health: " + GlobalVariableScript.Instance.playerHealth.ToString();
        scoreText.text ="Score: " + (GlobalVariableScript.Instance.enemyDestroyed * 1000).ToString();

        if(GlobalVariableScript.Instance.playerHealth<=0)
        {
            loseText.gameObject.SetActive(true);
        }
    }
}
