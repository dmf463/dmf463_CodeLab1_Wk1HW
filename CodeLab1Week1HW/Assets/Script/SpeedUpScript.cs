using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpScript : MonoBehaviour {

    GameObject gameManager;
    GameManagerScript gameManagerScript;

    GameObject player1;
    GameObject player2;

    PlayerControlScript Player1ControlScript;
    PlayerControlScript Player2ControlScript;

    public bool speedUp;
    float speedTimer;

    public float player1SpeedBoost;
    public float player2SpeedBoost;

    // Use this for initialization
    void Start () {

        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        Player1ControlScript = player1.GetComponent<PlayerControlScript>();
        Player2ControlScript = player2.GetComponent<PlayerControlScript>();

    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "player1")
        {
            player1SpeedBoost = 2;
            speedUp = true;
            Destroy(this.gameObject);
            Debug.Log(other.gameObject.name + " speed= " + Player1ControlScript.speed);
        }

        if (other.gameObject.tag == "player2")
        {
            player2SpeedBoost = 2;
            speedUp = true;
            Destroy(this.gameObject);
            Debug.Log(other.gameObject.name + " speed= " + Player2ControlScript.speed);
        }
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("Player 1 Speed = " + Player1ControlScript.speed);
        //Debug.Log("Player 2 Speed = " + Player2ControlScript.speed);

        //Debug.Log("speed timer = " + speedTimer);
        //speedTimer += Time.deltaTime;

        //if (speedUp == true)
        //{
        //    speedTimer += Time.deltaTime;
        //}

        //if (speedTimer > 5)
        //{
        //    speedUp = false;
        //    speedTimer = 0;
        //    player1SpeedBoost = 1;
        //    player2SpeedBoost = 1;
        //}
		
	}
}
