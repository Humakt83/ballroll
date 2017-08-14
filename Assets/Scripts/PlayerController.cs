using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text scoreText;
    public Text winText;
    //private Rigidbody rigidBody;
    private int scoreCount;    

    private void Start() {
        //rigidBody = GetComponent<Rigidbody>();
        scoreCount = 0;
        SetScoreText();
        winText.text = "";
    }

    /**private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidBody.AddForce(movement * speed);
    }**/

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            scoreCount++;
            SetScoreText();
        }
    }

    private void SetScoreText() { 
        scoreText.text = "Score: " + scoreCount;
        if (scoreCount >= 12) {
            winText.text = "Victory";
        }
    }
}
