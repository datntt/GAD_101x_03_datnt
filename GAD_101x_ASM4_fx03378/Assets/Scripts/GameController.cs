using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    float m_spawnTime;
    int score;
    //
    

    bool isGameOver = false;

    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            m_spawnTime = 0;
            
            // set high score
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            // show 
            m_ui.ShowGameoverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;

        if(m_spawnTime <= 0)
        {
            SpawnEnemy();

            m_spawnTime = spawnTime;
        }
    }
    public void Reset()
    {
        PlayerPrefs.SetInt("HighScore", 0);// set high score
    }

    // create enemy random
    public void SpawnEnemy()
    {
        float randXpos = Random.Range(-2.5f, 2.5f);

        Vector2 spawnPos = new Vector2(randXpos, 5.25f);

        if(enemy)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }
    // replay game
    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void SetScore(int value)
    {
        score = value;
    }

    public int GetScore()
    {
        return score;
    }
    public void ScoreIncrement()
    {
        if (isGameOver)
            return;
        score++;
        m_ui.SetScoreText("Score: " + score);
    }

    public void SetGameOverState(bool state)
    {
        isGameOver = state;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
