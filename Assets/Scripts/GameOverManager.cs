using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    public GameObject gameOverScreen;
    public static bool isGameOver = false;

    public AudioSource backgroundMusic;
    public AudioSource deathTheme;

    public void ShowGameOverScreen() {
        gameOverScreen.SetActive(true);
        isGameOver = true; 
        Time.timeScale = 0;

        if (backgroundMusic.isPlaying) {
            backgroundMusic.Stop();
        }

        if (!deathTheme.isPlaying) {
            deathTheme.Play();
        }
        // Debug.Log("Game Over Screen should be visible now.");
    }

    public void TryAgain() {
        Time.timeScale = 1;
        isGameOver = false; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu() {
        Time.timeScale = 1;
        isGameOver = false;
        SceneManager.LoadScene("MainMenu");
    }
}
