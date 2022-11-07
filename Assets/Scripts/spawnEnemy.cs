using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject shooter_Enemy;
    public float speed;
    float timer;
    bool isTimeStarted = true;
    public TextMeshProUGUI timer_text;
    public GameObject border;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn_Enemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int temp = Random.Range(0, 2);
            Debug.Log(temp);
        }

        if (isTimeStarted == false)
            return;
        timer += Time.deltaTime;
        timer_text.text ="Time : " +timer.ToString("00");
       // Debug.Log(timer);
    }

    IEnumerator spawn_Enemy()
    {
        float total_rocket = Random.Range(1f, 3f);
        if(timer>40f)
        {
            total_rocket = 4f;
        }

        for (int i = 0; i < total_rocket; i++)
        {
            spawn();
        }

        if (timer > 60f)
        {
            timer_text.gameObject.SetActive(false);
            StartCoroutine(SpawnBoss());
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            StartCoroutine(spawn_Enemy());
        }
    }

    public void Setvelocity(Rigidbody2D rb)
    {
        rb.velocity = Vector2.down * speed * Time.deltaTime;
    }

    void spawn()
    {
        if (timer < 20f)
        {
            Instantiate(enemy, new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f)), Quaternion.identity);
            return;
        }
        else if (timer < 40f)
        {
            for (int i = 0; i < 4; i++)
            {
                int temp = Random.Range(0, 5);
                if (temp == 0 || temp == 1 || temp == 2 || temp == 3)
                {
                    Instantiate(enemy, new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f)), Quaternion.identity);
                }
                else if (temp == 4)
                {
                    Instantiate(shooter_Enemy, new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f)), Quaternion.identity);
                }
            }
            return;
          
        }
        else if(timer < 60f)
        {
            for (int i = 0; i < 8; i++)
            {
                int temp = Random.Range(0, 5);
                if (temp == 0 || temp == 1)
                {
                    Instantiate(enemy, new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f)), Quaternion.identity);
                }
                else if (temp == 4 || temp == 3 || temp == 2)
                {
                    Instantiate(shooter_Enemy, new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f)), Quaternion.identity);
                }
            }
           
        }
       
    }

    IEnumerator SpawnBoss()
    {
        border.gameObject.SetActive(false);
        boss.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
    }
}
