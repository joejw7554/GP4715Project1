using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    private float timeLeft= 120;
    public int playerScore=0;

    void Update()
    {
        //Debug.Log (timeLeft);
        timeLeft-=Time.deltaTime;

        if(timeLeft<0.1f)
        {
            SceneManager.LoadScene ("Level1");
        }
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        //Debug.Log("Touched");
        CountScore();
    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft*10);
        Debug.Log (playerScore);
    }
}
