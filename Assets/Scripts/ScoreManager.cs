using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static void SaveScore(int level, int score) {
        // Save the score for a specific level
        PlayerPrefs.SetInt("Level" + level + "Score", score);
        PlayerPrefs.Save(); // Ensure data is written to disk
    }

    public static int GetScore(int level) {
        // Retrieve the score for a specific level, default to 0 if not found
        return PlayerPrefs.GetInt("Level" + level + "Score", 0);
    }

    public static int GetHighScore() {
        // Retrieve the higher of the two level scores
        int level1Score = GetScore(1);
        int level2Score = GetScore(2);
        return Mathf.Max(level1Score, level2Score);
    }
}
