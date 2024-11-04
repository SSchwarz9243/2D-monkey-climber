using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using UnityEngine.SceneManagement; // Import for SceneManager

public class Player_Score : MonoBehaviour {

    private float timeLeft = 120;
    public int playerScore = 0;
    public TMP_Text timeText; // Reference to the TextMeshPro component for time
    public TMP_Text scoreText; // Reference to the TextMeshPro component for score

    // Start is called before the first frame update
    void Start() {
        // Ensure text components are set either via the Inspector or dynamically found
        if (timeText == null || scoreText == null) {
         //   Debug.LogError("TextMeshPro components not set!");
        }
    }

    // Update is called once per frame
    void Update() {
        timeLeft -= Time.deltaTime;
        
        // Update the TextMeshPro components with the current time and score
        timeText.text = "Time Left: " + Mathf.Ceil(timeLeft).ToString();
        scoreText.text = "Score: " + playerScore.ToString();

        if (timeLeft < 0.1f) {
            SceneManager.LoadScene("Main");
        }
    }

    // Call this method to increase the score
    public void IncreaseScore(int amount) {
        playerScore += amount;
        Debug.Log("IncreaseScore called. Current score: " + playerScore); // Debug log for checking
        scoreText.text = "Score: " + playerScore.ToString(); // Update the UI text
        scoreText.ForceMeshUpdate(); // Ensure the UI refreshes immediately
}


    // Detect when the player collides with a banana
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("banana")) {
            Debug.Log("Banana collected! Score increased by 10."); // Add this for debugging
            IncreaseScore(10);
            Destroy(other.gameObject); // Destroy the banana GameObject
        }
    }

}
