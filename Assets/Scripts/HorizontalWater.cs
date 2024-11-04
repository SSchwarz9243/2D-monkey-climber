using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalWater : MonoBehaviour {
    public float riseSpeed = 3.0f; 
    public GameOverManager gameOverManager; 

    void Update() {
        transform.position += Vector3.right * riseSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
  //  Debug.Log("Collision detected with: " + other.gameObject.name); 

    if (other.CompareTag("Player")) {
        // Debug.Log("Player touched the water!");
        gameOverManager.ShowGameOverScreen(); 
       // Debug.Log("ShowGameOverScreen() was called from moving water");
     }
    }

}
