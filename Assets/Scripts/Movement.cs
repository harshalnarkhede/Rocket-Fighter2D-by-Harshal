using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    Vector2 direction;
    public int Boss_health = 300;

    public GameObject powerup;
    public GameObject speedup;

    public int total_speedup =0;
    public int total_powerup= 0;
    public int total;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI PowerupText;
    public TextMeshProUGUI SpeedUptext;
    public int score;

    public TextMeshProUGUI scoreText1;
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject looseMenu;
    public GameObject GamePanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0f;
            looseMenu.SetActive(true);
        }
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            Time.timeScale = 0f;
            looseMenu.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        direction = new Vector2(horizontal, vertical);
        scoreText.text = "Score : "+score.ToString();
        scoreText1.text = "Score : " + score.ToString();
       


        if (total_powerup < 2)
        {
            PowerupText.text = "Power Up : " + total_powerup;
        }
        else
        {
            PowerupText.text = "Power Up : Max";
        }

        if (total_speedup < 3)
        {
            SpeedUptext.text = "Speed Up : " + total_speedup;
        }
        else
        {
            SpeedUptext.text = "Speed Up : Max";
        }
     }

    private void FixedUpdate()
    {
        if (direction.magnitude < 0.1f)
            return;

        rb.velocity =direction * speed * Time.deltaTime;
    }

    public void Normal_Time()
    {
        GamePanel.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Stop_Time()
    {
        GamePanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void loadScene()
    {
        SceneManager.LoadScene(0);
    }
}
