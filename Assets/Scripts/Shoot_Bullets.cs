using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Bullets : MonoBehaviour
{
    public GameObject shootPoint;

    public GameObject shootPoint_Side1;
    public GameObject shootPoint_Side2;

    public GameObject shootPoint_angle1;
    public GameObject shootPoint_angle2;


    public GameObject bullets;
    public LayerMask lm;
    public float bullet_Speed;
    public float speedup =0.4f;
    public float powerup =1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("powerup"))
        {
            if (powerup < 3f)
            {
                powerup = powerup + 1;             
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("speedup"))
        {
          
            if (speedup > 0.1f)
            {
                speedup = speedup - .1f;  
                if(speedup<=0.1f)
                {
                    speedup = 0.1f;
                }
            }
            Destroy(collision.gameObject);
        }
    }
    void Start()
    {
        StartCoroutine(Start_Shooting());
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.transform.position, Vector2.up,lm);            
    }

    IEnumerator Start_Shooting()
    {
        if (powerup == 1f)
        {
            GameObject temp_Bullet = Instantiate(bullets, shootPoint.transform.position, Quaternion.identity);
            temp_Bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bullet_Speed * Time.deltaTime;
        }
        else if(powerup == 2f)
        {
            GameObject temp_Bullet = Instantiate(bullets, shootPoint.transform.position, Quaternion.identity);
            temp_Bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bullet_Speed * Time.deltaTime;

            GameObject temp_Bullet2 = Instantiate(bullets, shootPoint_Side1.transform.position, Quaternion.identity);
            temp_Bullet2.GetComponent<Rigidbody2D>().velocity = Vector2.up * bullet_Speed * Time.deltaTime;

            GameObject temp_Bullet3 = Instantiate(bullets, shootPoint_Side2.transform.position, Quaternion.identity);
            temp_Bullet3.GetComponent<Rigidbody2D>().velocity = Vector2.up * bullet_Speed * Time.deltaTime;
        }
        else if (powerup == 3f)
        {
            GameObject temp_Bullet = Instantiate(bullets, shootPoint.transform.position, Quaternion.identity);
            temp_Bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bullet_Speed * Time.deltaTime;

            GameObject temp_Bullet2 = Instantiate(bullets, shootPoint_Side1.transform.position, Quaternion.identity);
            temp_Bullet2.GetComponent<Rigidbody2D>().velocity = Vector2.up * bullet_Speed * Time.deltaTime;

            GameObject temp_Bullet3 = Instantiate(bullets, shootPoint_Side2.transform.position, Quaternion.identity);
            temp_Bullet3.GetComponent<Rigidbody2D>().velocity = Vector2.up * bullet_Speed * Time.deltaTime;

            GameObject temp_Bullet4 = Instantiate(bullets, shootPoint_angle1.transform.position, Quaternion.EulerAngles(0f,0f,-0.5235f));
            temp_Bullet4.GetComponent<Rigidbody2D>().velocity = new Vector2(1f,2f) * bullet_Speed * Time.deltaTime;

            GameObject temp_Bullet5 = Instantiate(bullets, shootPoint_angle2.transform.position, Quaternion.EulerAngles(0f, 0f, 0.5235f));
            temp_Bullet5.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 2f) * bullet_Speed * Time.deltaTime;
        }

        yield return new WaitForSeconds(speedup);
        StartCoroutine(Start_Shooting());
    }    
}