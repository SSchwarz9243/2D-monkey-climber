using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class Player_Score : MonoBehaviour {

    private float timeLeft = 120;
    public int playerScore = 0;
    public TMP_Text timeText; 
    public TMP_Text scoreText; 

    
    void Start() {
        
        if (timeText == null || scoreText == null) {
         //   Debug.LogError("TextMeshPro components not set!");
        }
    }

    void Update() {
        timeLeft -= Time.deltaTime;
        
        timeText.text = "Time Left: " + Mathf.Ceil(timeLeft).ToString();
        scoreText.text = "Score: " + playerScore.ToString();

        if (timeLeft < 0.1f) {
            SceneManager.LoadScene("Main");
        }
    }

    public void IncreaseScore(int amount) {
        playerScore += amount;
       // Debug.Log("IncreaseScore called. Current score: " + playerScore); 
        scoreText.text = "Score: " + playerScore.ToString(); 
        scoreText.ForceMeshUpdate(); 
}


    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("banana")) {
           // Debug.Log("Banana collected! Score increased by 10."); 
            IncreaseScore(10);
            Destroy(other.gameObject); 
        }
    }

}
