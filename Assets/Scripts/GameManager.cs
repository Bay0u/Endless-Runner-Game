using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMove playerMove;
    public int score;
    public int speed;
    public int coinsn;
    public int spheresn;
    public static GameManager inst;
    public Text ScorePoints;
    public Text CoinsCollected;
    public Text BlueSpheresCollected;
    public Text SpeedT;
    public Text invincibleT;
    int counter1 = 0;
    int counter2 = 0;
    public bool invincible = false;
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    private void stopAudio()
    {
        

    }
    public void IncrementScore(string obj)
    {
        if (obj == "coin")
        {
            score=score+15;
            coinsn++;
            ScorePoints.text = "SCORE = " + score;
            CoinsCollected.text = "Coins = " +coinsn;
            counter2++;
            if (counter2 == 3)
            {
                playerMove.cam1.GetComponentInChildren<AudioSource>().Stop();
                sounds.audioSrc.Stop();
                sounds.PlaySound("invinsable");
                invincible = true;
                invincibleT.text = "invincible = " + invincible;
                Invoke("reinvinsable", 5f);
                
            }
        }
        if (obj == "BSphere")
        {
            score = score + 10; 
            spheresn++;
            ScorePoints.text = "SCORE = " + score;
            BlueSpheresCollected.text = "Blue Spheres = " + spheresn;
            counter1++;
            if (counter1 == 3)
            {
                playerMove.Speed = playerMove.Speed * 2;
                SpeedT.text = "Speed = " +playerMove.Speed;
                Invoke("respeed",7f);
            }
        }
    }
    public void DecrementScore()
    {
        if (!invincible)
        {
            sounds.PlaySound("losing");
            score = score - 10;
            if (score < 0)
            {
                playerMove.Die();
            }
            ScorePoints.text = "SCORE = " + score;
        }

        
        
    }
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escape();
        }
        
    }
    void reinvinsable()
    {
        invincible = false;
        invincibleT.text = "invincible = " + invincible;
        sounds.audioSrc.Stop();
        playerMove.cam1.GetComponentInChildren<AudioSource>().Play();
        counter2 = 0;
    }
    public void escape()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    void respeed()
    {
        playerMove.Speed = playerMove.Speed / 2;
        SpeedT.text = "Speed = " + playerMove.Speed;
        counter1 = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        sounds.audioSrc.Stop();
        playerMove.cam1.GetComponentInChildren<AudioSource>().Play();
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }
    public void Pause()
    {
        playerMove.cam1.GetComponentInChildren<AudioSource>().Stop();
        sounds.audioSrc.Stop();
        sounds.PlaySound("chill");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        /*sounds.audioSrc.Stop();
        playerMove.cam1.GetComponentInChildren<AudioSource>().Play();*/
    }
}
