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
    public GameObject bulletHolder;


    public float eventTime = 5.0f;
    public GameObject win;
    private bool direction = true;
    public float judderSpeed = 0.05f;
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
            timer = 0.0f;
        }
      
    }
    private void FixedUpdate()
    {
        if(transform.position.x>5||transform.position.x<-5)
        {
            direction = !direction;
        }
        if(direction)
        {
            transform.position += new Vector3(judderSpeed, 0.0f, 0.0f);
        }
        else
        {
            transform.position += new Vector3(-judderSpeed, 0.0f, 0.0f);
        }
    }

    public void Kill()
    {
        enemyDestroyed++;
        GlobalVariableScript.Instance.enemyDestroyed++;
        if(enemyDestroyed>= rows*columns*0.25)
        {
            judderSpeed = 0.1f;
        }
        if (enemyDestroyed >= rows * columns * 0.5)
        {
            judderSpeed = 0.2f;
        }
        if (enemyDestroyed >= rows * columns * 0.75)
        {
            judderSpeed = 0.4f;
        }
        if (enemyDestroyed >= rows * columns)
        {
            win.SetActive(true);
        }
    }
    public void TriggerEvent()
    {
        //bulletHolder.GetComponent<BulletsScript>().Fire(new Vector3(-10.0f, 0.0f, 0.0f), new Vector3(-0.5f, 0.0f, 0.0f));
    }
}
