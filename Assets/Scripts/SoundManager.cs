using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource deathTheme;

    public void PlayerDied()
    {
        backgroundMusic.Stop();
        
        deathTheme.Play();
    }
}
