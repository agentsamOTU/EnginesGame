using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalVariableScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static GlobalVariableScript Instance;

    public int playerHealth = 10;

    public Text message;

    public Queue<string> messageQueue = new Queue<string>();
    
    [SerializeField] private float messageTime;
    private float messageTimer;

    private void Update()
    {
        if (messageQueue.Count > 0)
        {
            message.text = messageQueue.Peek();
            messageTimer += Time.deltaTime;
            if (messageTimer >= messageTime)
            {
                messageTimer = 0.0f;
                messageQueue.Dequeue();
            }
        }
        else
            message.text = "";
       
    }

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
