using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayHighScore : MonoBehaviour {
    public TMP_Text highScoreText;

    void Start() {
        int totalScore = PlayerPrefs.GetInt("TotalScore", 0);

       // Debug.Log("Retrieved Total Score: " + totalScore);

       
        highScoreText.text = "High Score: " + totalScore.ToString();
    }

    public void TryAgain() {
        PlayerPrefs.DeleteKey("TotalScore"); 
        SceneManager.LoadScene("Main");
    }

    public void ExitToMainMenu() {
        SceneManager.LoadScene("MainMenu"); 
    }

    public void ExitToDesktop() {
        Application.Quit();
      //  Debug.Log("Game is exiting...");
    }
}



