using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private float timeLeft= 120;
    public int playerScore=0;
    public GameObject timeUI;
    public GameObject playerScoreUI;


    void Update()
    {
        timeLeft-=Time.deltaTime;
        timeUI.gameObject.GetComponent<Text>().text=("Time: "+ (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text=("Score:"+ playerScore);

        if(timeLeft<0.1f)
        {
            SceneManager.LoadScene ("Level1");
        }
    }

    void OnTriggerEnter2D (Collider2D trig)
    {
        if(trig.gameObject.name =="EndLevel")
        {
            CountScore();
        }

        if(trig.gameObject.name =="Coin")
        {
            playerScore+=10;
            Destroy(trig.gameObject);
        }
    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft*10);
    }
}
