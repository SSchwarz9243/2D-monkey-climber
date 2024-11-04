using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingLava : MonoBehaviour {
    public float riseSpeed = 0.75f;
    public GameOverManager gameOverManager;

    void Update() {
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
  //  Debug.Log("Collision detected with: " + other.gameObject.name);

    if (other.CompareTag("Player")) {
        // Debug.Log("Player touched the lava!");
        gameOverManager.ShowGameOverScreen();
       // Debug.Log("ShowGameOverScreen() was called from RisingLava");
     }
    }

}


