using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesScript : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject UI;
    public int rows;
    public int columns;
    public int enemyDestroyed;
    public float timer = 0.0f;

    public float eventTime = 5.0f;
    public GameObject win;
    // Start is called before the first frame update
    void Start()
    {
        win = UI.GetComponentsInChildren<Text>()[0].gameObject;
        win.SetActive(false);

        for (int i = 0; i<rows;i++)
        {
            for (int j = 0; j<columns;j++)
            {
                GameObject newEnemy = Instantiate(Enemy, new Vector3(40 / columns * j - 16 ,0.0f, 10 / rows * i + 0), Quaternion.identity);
                newEnemy.transform.SetParent(transform);
                newEnemy.GetComponent<EnemyScript>().parent=this;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>eventTime)
        {
            TriggerEvent();
        }
        if(enemyDestroyed>=rows*columns)
        {
            win.SetActive(true);
        }
    }

    public void Kill()
    {
        enemyDestroyed++;
        GlobalVariableScript.Instance.enemyDestroyed++;
    }
    public void TriggerEvent()
    {

    }
}
