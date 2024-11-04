using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour {
    private float timeLeft = 120;
    public int playerScore = 0;
    public TMP_Text timeLeftUI;
    public TMP_Text playerScoreUI;
    public string levelName; 

    void Start() {
        playerScore = PlayerPrefs.GetInt("TotalScore", 0);
    }

    void Update() {
        timeLeft -= Time.deltaTime;
        timeLeftUI.text = "Time Left: " + Mathf.CeilToInt(timeLeft).ToString();
        playerScoreUI.text = "Score: " + playerScore.ToString();

        if (timeLeft < 0.1f) {
            SaveLevelScore();
            SceneManager.LoadScene("EndGame");
        }
    }

    void OnTriggerEnter2D(Collider2D trig) {
        if (trig.CompareTag("banana")) {
            CountScore();
            Destroy(trig.gameObject);
        }
    }

    void CountScore() {
        playerScore += 10;
       // Debug.Log("Score updated: " + playerScore);
    }

    void SaveLevelScore() {
 
        int totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        totalScore += playerScore;
        PlayerPrefs.SetInt("TotalScore", totalScore);
        PlayerPrefs.Save();

        // Debug.Log("Saved " + levelName + " Score: " + playerScore);
        // Debug.Log("Updated Total Score: " + totalScore);
    }
}




