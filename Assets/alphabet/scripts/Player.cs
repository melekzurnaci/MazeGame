using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Text gorevText;
    public Text scoreText;
    public Text highScoreText;
    public int score = 0;
    private int kosul = 0;
    public int highScore = 0;
    public float gameOverDelay = 2f;
    public string gameOverSceneName = "GameOver";

    public int randomNum;
    public string randomHarf;
    string[] harfler;

    // Start is called before the first frame update
    void Start()
    {
       // highScoreText = GameObject.Find("highScoreText").GetComponent<Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    

    void OnTriggerEnter2D(Collider2D target)
    {

        Debug.Log(randomHarf + " " + randomNum);
        if (kosul < randomNum)
        {
            if (randomHarf.Equals(harfler[0]))
            {
                Debug.Log(" kosul B harfi");
                if (target.tag.Equals("Dharf"))
                {
                    StartCoroutine(GameOver());
                    //  transform.position = new Vector2(0, 100);
                    target.gameObject.SetActive(false);

                }
                
                if (target.tag.Equals("Bharf"))
                {
                
                    AddScore();
                    kosul++;

                    target.gameObject.SetActive(false);
                    
                }
                if (target.tag.Equals("Pharf"))
                {
                    StartCoroutine(GameOver());
                    target.gameObject.SetActive(false);
                }
              

            }
            if (randomHarf.Equals(harfler[1]))
            {
                Debug.Log("D harfi sorgu");
                if (target.tag.Equals("Bharf"))
                {
                    StartCoroutine(GameOver());
                    target.gameObject.SetActive(false);
                   
                   
                }
                // eğer çarpışan nesne  b harf ise score++ olur
                if (target.tag.Equals("Dharf"))
                {
                     target.gameObject.SetActive(false);
                    AddScore();
                    kosul++;

                }
                if (target.tag.Equals("Pharf"))
                {
                    StartCoroutine(GameOver());
                    target.gameObject.SetActive(false);

                    
                }
             
                
            }
            if (randomHarf.Equals(harfler[2]))
            {
                Debug.Log("P harfi sorgu");
                if (target.tag.Equals("Bharf"))
                {
                    StartCoroutine(GameOver());
                    target.gameObject.SetActive(false);
                    
                }
                // eğer çarpışan nesne  b harf ise score++ olur
                if (target.tag.Equals("Dharf"))
                {
                    StartCoroutine(GameOver());
                    target.gameObject.SetActive(false);

                }
                if (target.tag.Equals("Pharf"))
                {
                    
                    AddScore();
                    kosul++;
                }
                
               
            }

        }

        if (kosul == randomNum)
        {
            CreateRandom();
            kosul = 0;
            
        }
    }

    void CreateRandom()
    {
        // 1 ile 5 arası random değer oluşturup randomNum a atıyoruz.
        randomNum = Random.Range(1, 5);
        // burada harfler dizisi içindekileri random şekilde seçip randomHarf e atadık.
        harfler = new string[] { "B harfi", "D harfi" ,"P harfi"};
        randomHarf = harfler[Random.Range(0, harfler.Length)];
        gorevText = GameObject.Find("gorevText").GetComponent<Text>();
        gorevText.text = (randomNum + " " + randomHarf);
        Debug.Log("createrandom " + randomHarf + " " + randomNum);

    }


    void AddScore()
    {
        score++;
        scoreText.text = score.ToString("0");
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString();
           // SaveLoadManager.SaveScores(score, highScore);

        }
       // PlayerPrefs.SetInt("highScoreText", highScore);

    }
   


    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene(gameOverSceneName);
    }
   
}
