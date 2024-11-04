using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayHighScore : MonoBehaviour {
    public TMP_Text highScoreText;

    void Start() {
        // Retrieve the total score from PlayerPrefs
        int totalScore = PlayerPrefs.GetInt("TotalScore", 0);

        // Debug log to check the total score
        Debug.Log("Retrieved Total Score: " + totalScore);

        // Display the total score as the high score
        highScoreText.text = "High Score: " + totalScore.ToString();
    }

    public void TryAgain() {
        PlayerPrefs.DeleteKey("TotalScore"); // Optionally reset the total score for a new game
        SceneManager.LoadScene("Main"); // Load the first level
    }

    public void ExitToMainMenu() {
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }

    public void ExitToDesktop() {
        Application.Quit();
        Debug.Log("Game is exiting...");
    }
}



