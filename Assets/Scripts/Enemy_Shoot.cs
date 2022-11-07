using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootPoint1;
    public GameObject shootPoint2;
    public GameObject shootPoint3;
    public float bullet_Speed;
   
    private void Awake()
    {
        StartCoroutine(Start_Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Start_Shooting()
    {
        yield return new WaitForSeconds(Random.Range(0f,2f));

        GameObject temp_Bullet1 = Instantiate(bullet, shootPoint1.transform.position, Quaternion.identity);
        temp_Bullet1.GetComponent<Rigidbody2D>().velocity = Vector2.down * bullet_Speed * Time.deltaTime;

        if (shootPoint2 != null)
        {
            GameObject temp_Bullet2 = Instantiate(bullet, shootPoint2.transform.position, Quaternion.identity);
            temp_Bullet2.GetComponent<Rigidbody2D>().velocity = Vector2.down * bullet_Speed * Time.deltaTime;
        }

        if (shootPoint3 != null)
        {
            GameObject temp_Bullet3 = Instantiate(bullet, shootPoint3.transform.position, Quaternion.identity);
            temp_Bullet3.GetComponent<Rigidbody2D>().velocity = Vector2.down * bullet_Speed * Time.deltaTime;
        }
        if (this.gameObject.CompareTag("Enemy"))
        {
            yield return new WaitForSeconds(4f);
        }
        else if(this.gameObject.CompareTag("Boss"))
        {
            yield return new WaitForSeconds(.3f);
        }
        StartCoroutine(Start_Shooting());
    }
}
