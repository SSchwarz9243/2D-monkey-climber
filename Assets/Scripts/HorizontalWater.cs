using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalWater : MonoBehaviour {
    public float riseSpeed = 1.0f; // Adjust the speed of the moving water
    public GameOverManager gameOverManager; // Reference to the GameOverManager script

    void Update() {
        transform.position += Vector3.right * riseSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
  //  Debug.Log("Collision detected with: " + other.gameObject.name); // Check if this prints

    if (other.CompareTag("Player")) {
        // Debug.Log("Player touched the water!");
        gameOverManager.ShowGameOverScreen(); // Ensure this line is active
       // Debug.Log("ShowGameOverScreen() was called from moving water");
     }
    }

}
