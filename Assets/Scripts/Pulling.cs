using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulling : MonoBehaviour
{
    public Movement movement;

    int total;

    private void Awake()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("border"))
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            movement.score = movement.score + 1;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

            if (movement.total < 5)
            {
                int random_Number = Random.Range(0, 5);
                if (random_Number == 3f)
                {
                    int random_Number1 = Random.Range(0, 2);
                    Debug.Log(random_Number1);
                    if (random_Number1 == 0)
                    {
                        if (movement.total_speedup == 3)
                            return;
                        Instantiate(movement.speedup, transform.position, Quaternion.identity);
                        movement.total_speedup++;
                    }
                    if (random_Number1 == 1)
                    {
                        if (movement.total_powerup == 2)
                            return;
                        Instantiate(movement.powerup, transform.position, Quaternion.identity);
                        movement.total_powerup++;
                    }
                    movement.total = movement.total_powerup + movement.total_speedup;
                }
            }
            movement.score = movement.score+3;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }


        if (collision.gameObject.CompareTag("Boss"))
        {
            movement.score = movement.score + 6;
            movement.Boss_health = movement.Boss_health - 1;
            Debug.Log(movement.Boss_health);
            if(movement.Boss_health <=0)
            {
                Destroy(collision.gameObject);
                Time.timeScale = 0f;
                movement.winMenu.SetActive(true);
            }
            Destroy(this.gameObject);
        }
    }
}
