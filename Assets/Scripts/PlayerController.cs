using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text scoreText;
    public Text winText;
    private int scoreCount;    

    private void Start() {
        scoreCount = 0;
        SetScoreText();
        winText.text = "";
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            scoreCount++;
            SetScoreText();
        } else if (other.gameObject.CompareTag("Danger")) {
            GameOver("Game Over!");
        }
    }

    private void SetScoreText() { 
        scoreText.text = "Score: " + scoreCount;
        if (scoreCount >= 12) {
            GameOver("Victory!");
        }
    }

    private void GameOver(string text) {
        winText.text = text;
        this.gameObject.SetActive(false);
    }
}
