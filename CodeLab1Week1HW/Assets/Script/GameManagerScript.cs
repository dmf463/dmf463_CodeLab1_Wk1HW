using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    //THINGS TO ADD
    //Add in Pickup Objects that can SLOW DOWN a player or SPEED UP a player.
    //Add in TRAPS. When you're an ATTACKER you get TWO traps you can lay.

    GameObject Player1;
    GameObject Player2;

    PlayerControlScript Player1ControlScript;
    PlayerControlScript Player2ControlScript;

    public bool player1Attacker;
    public bool player2Attacker;

    public bool timerOn;

    public float attacker;

    TextMesh countDown;
    TextMesh player1Score;
    TextMesh player2Score;
    float player1ScoreCounter;
    float player2ScoreCounter;
    public float timer;

    float pointTimer;

    GameObject GameOver;

    public float increaseSpeed;
    public float increaseSize;

    GameObject sonic;
    SpeedUpScript speedUpScript;

	// Use this for initialization
	void Start () {

        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");

        GameOver = GameObject.Find("GameOver");
        GameOver.GetComponent<MeshRenderer>().enabled = false;

        Player1ControlScript = Player1.GetComponent<PlayerControlScript>();
        Player2ControlScript = Player2.GetComponent<PlayerControlScript>();

        player1Attacker = false;
        player2Attacker = false;

        attacker = Random.Range(1, 3);

        countDown = GameObject.Find("Countdown").GetComponent<TextMesh>();

        player1Score = GameObject.Find("Score1").GetComponent<TextMesh>();
        player2Score = GameObject.Find("Score2").GetComponent<TextMesh>();

        player1ScoreCounter = 0;
        player2ScoreCounter = 0;

        sonic = GameObject.Find("Sonic");
        speedUpScript = sonic.GetComponent<SpeedUpScript>();


        timer = 10.5f;
        timerOn = true;

        increaseSpeed = 0;
        increaseSize = 0;

	}
	
	// Update is called once per frame
	void Update () {

        //a random number is generated to decide who will be the attacker at the beginning of the round
        //all the other lines are inputted so that players will switch roles when they make contact

        player1Score.text = "" + player1ScoreCounter;
        player2Score.text = "" + player2ScoreCounter;

        if (attacker == 1)
        {
            Player1.transform.localScale = new Vector3(4f + increaseSize, 4f + increaseSize, 4f + increaseSize);
            Player2.transform.localScale = new Vector3(1f + increaseSize, 1f + increaseSize, 1f + increaseSize);
            Player1ControlScript.speed = (15f + increaseSpeed) * speedUpScript.player1SpeedBoost;
            Player2ControlScript.speed = (25f + increaseSpeed) * speedUpScript.player2SpeedBoost;
            player1Attacker = true;
            player2Attacker = false;
            Debug.Log("Attacker = 1");

            pointTimer = pointTimer + Time.deltaTime;

            if (pointTimer > 2)
            {
                pointTimer = 0;
                player2ScoreCounter += 1;
            }

        }

        if (attacker == 2)
        {
            Player2.transform.localScale = new Vector3(4f + increaseSize, 4f + increaseSize, 4f + increaseSize);
            Player1.transform.localScale = new Vector3(1f + increaseSize, 1f + increaseSize, 1f + increaseSize);
            Player1ControlScript.speed = (15f + increaseSpeed) * speedUpScript.player1SpeedBoost;
            Player2ControlScript.speed = (25f + increaseSpeed) * speedUpScript.player2SpeedBoost;
            player2Attacker = true;
            player1Attacker = false;
            Debug.Log("Attcker = 2");

            pointTimer = pointTimer + Time.deltaTime;
            if (pointTimer > 2)
            {
                pointTimer = 0;
                player1ScoreCounter += 1;
            }
        }

        if (timerOn == true)
        {
            timer = timer - Time.deltaTime;
            countDown.text = "" + timer;
        }

        if (timer < 0)
        {
            timerOn = false;
            timer = 0;

            GameOver.GetComponent<MeshRenderer>().enabled = true;
            Player1ControlScript.enabled = false;
            Player2ControlScript.enabled = false;
        }


    }
}
