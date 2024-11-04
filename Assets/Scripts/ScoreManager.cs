using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static void SaveScore(int level, int score) {
        
        PlayerPrefs.SetInt("Level" + level + "Score", score);
        PlayerPrefs.Save(); 
    }

    public static int GetScore(int level) {
        return PlayerPrefs.GetInt("Level" + level + "Score", 0);
    }

    public static int GetHighScore() {
        int level1Score = GetScore(1);
        int level2Score = GetScore(2);
        return Mathf.Max(level1Score, level2Score);
    }
}
