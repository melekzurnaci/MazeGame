using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerDog : MonoBehaviour
{
    public float speed = 5.0f;
    public int score = 0;
    public int highscore = 0;
    public int nesne = 0;
    public Text timebox;
    public Text ScoreAmount;
    public Text highScore;
    public Text highScoreText;
    public float timestart=0;
    public Rigidbody2D player;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Score", score);
        ShowHighscore();
        player = GetComponent<Rigidbody2D>();
  
        score = 0;
        if (score > highscore)
        {
            highscore = score;
            highScore.text = "HighScore: " + highscore;
        }
       //  highScore.text = "HighSCore:" + PlayerPrefs.GetInt("highscore");
        Debug.Log(PlayerPrefs.GetInt("highscore"));
       
    }
    private void FixedUpdate()
    {
        move();
    }
   
    void Update()
    {
        if (timestart > 120)
        {
            SceneManager.LoadScene("MazeGame2GameOver");
        }
      
        ButtonControl();
     
        if (nesne >= 3)
        {
            Destroy(door);
        }
        timer();
       
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Cups"))
        {
            Debug.Log("hit the cups");
           
            nesne++;
            
            if (score < highscore)
            {
                highscore = score;
                PlayerPrefs.SetFloat("highscore", score);
            }
            Destroy(collision.gameObject);
            if (timestart < 20)
            {
                score = score + 10;
                ScoreAmount.text = "Score: " + score;
                PlayerPrefs.SetInt("highscore", score);//SEt veriyi kaydeder GET veriyi çağırır.
                Destroy(collision.gameObject);
            }
            else if (timestart < 40 && timestart >= 20)
            {
                score = score + 5;
                ScoreAmount.text = "Score: " + score;
                PlayerPrefs.SetInt("highscore", score);//SEt veriyi kaydeder GET veriyi çağırır.
                Destroy(collision.gameObject);
            }
            else if (timestart < 60 && timestart >= 40)
            {
                score=score + 3;
                ScoreAmount.text = "Score: " + score;
                PlayerPrefs.SetInt("highscore", score);//SEt veriyi kaydeder GET veriyi çağırır.
                Destroy(collision.gameObject);
            }
            else if (timestart >= 60)
            {
                score++;
                ScoreAmount.text = "Score: " + score;
                PlayerPrefs.SetInt("highscore", score);//SEt veriyi kaydeder GET veriyi çağırır.
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.tag.Equals("ABC"))
        {
            score = 15 + score;
            SceneManager.LoadScene("MazeGame1");

            // YouWin.text = "HARFLERİ KURTARDIN";
        }

        if (collision.gameObject.tag.Equals("Enemies"))
        {
          
         //   HeartControl();
             SceneManager.LoadScene("MazeGame2GameOver");
            //oyunu düşmana çarptığında tekrar başlatıyor.
             // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        if (collision.gameObject.tag.Equals("Walls"))
        {
            Debug.Log("hit the walls");
           
        }
    }
    public void ButtonControl()
    {
        if (Input.GetMouseButtonDown(0)) { moveleft(); }
        if (Input.GetMouseButtonDown(0)) { moveRight(); }

        if (Input.GetMouseButtonDown(0)) { moveUp(); }
        if (Input.GetMouseButtonDown(0)){ moveDown(); }
    }
    public void KeyKontrol()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

    }
    public void moveleft()
    {

        transform.Translate(-speed * Time.deltaTime, 0, 0);

    }
    public void moveRight()
    {

        transform.Translate(speed * Time.deltaTime, 0, 0);

    }
    public void moveDown()
    {

        transform.Translate(0, -speed * Time.deltaTime, 0);

    }
    public void moveUp()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

    }
    //public void heartCount()
    //{

    //    Heart--;
    //    if (Heart == 0)
    //    {
    //        //heartNum = true;
    //        SceneManager.LoadScene("MazeGameGameOver");
    //    }
    //}
    public void move()
    {
        Vector2 vel = player.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
    }
  

    void ShowHighscore()
    {
        float highscore = PlayerPrefs.GetFloat("HighScore");
        highScoreText.text = highscore.ToString();
    }
    //void HeartControl()
    //{
    //    switch (HeartVal)
    //    {
    //        case 3:
    //            heart1.gameObject.SetActive(true);
    //            heart2.gameObject.SetActive(true);
    //            heart3.gameObject.SetActive(true);
    //            break;

    //        case 2:
    //            heart1.gameObject.SetActive(true);
    //            heart2.gameObject.SetActive(true);
    //            heart3.gameObject.SetActive(false);
    //            break;

    //        case 1:
    //            heart1.gameObject.SetActive(true);
    //            heart2.gameObject.SetActive(false);
    //            heart3.gameObject.SetActive(false);
    //            break;

    //        case 0:
    //            heart1.gameObject.SetActive(false);
    //            heart2.gameObject.SetActive(false);
    //            heart3.gameObject.SetActive(false);
    //            SceneManager.LoadScene("MazeGameGameOver");
    //            break;


    //    }

    //}
    void timer()
    {
        timestart += Time.deltaTime;
        timebox.text = "Süre: " + Mathf.Round(timestart).ToString();
    }

}
