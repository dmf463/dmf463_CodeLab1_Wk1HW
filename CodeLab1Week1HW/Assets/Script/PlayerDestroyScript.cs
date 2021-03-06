﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDestroyScript : MonoBehaviour {

    GameObject goal;
    public float radius = 4f;

    GameObject centerPoint;

    GameObject gameManager;
    GameManagerScript GameManagerScript;
    PlayerControlScript playerControlScript;

    public float speed;
    public float hitBackDistance;

    public bool bounceBack;

    GameObject player1;
    GameObject player2;

    GameObject sonic;
    SpeedUpScript speedUpScript;

    public GameObject sonicPrefab;



    // Use this for initialization
    void Start () {

        goal = GameObject.Find("Goal");
        gameManager = GameObject.Find("GameManager");
        GameManagerScript = gameManager.GetComponent<GameManagerScript>();
        playerControlScript = GetComponent<PlayerControlScript>();

        centerPoint = GameObject.Find("CenterPoint");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        sonic = GameObject.Find("Sonic");
        speedUpScript = sonic.GetComponent<SpeedUpScript>();

    }

    public void OnCollisionEnter(Collision other)
    {
        //when the player collides with the other player, they switch roles.
        //ALSO:
        //After 10 seconds, if the attacker has not touched the other player, the Game is over.
        //points are accumulated not by how often the person is tagged, but rather by how LONG the player is able to dodge the attacker. For each 2 second that the player is chased, they accrue one point. No points are gained as the attacker. 
        //Camera pulls out
        //Gamespace increases
        //players move faster

        GameManagerScript.timer = 10;

        if (GameManagerScript.player1Attacker == true)
        {
            if (other.gameObject.name == "Player2")
            {
                GameManagerScript.attacker = 2;
            }
        }

        if (GameManagerScript.player2Attacker == true)
        {
            if (other.gameObject.name == "Player1")
            {
                GameManagerScript.attacker = 1;
            }
        }

        float step = speed * Time.deltaTime;

        //if the two players collide, they bounce back from each other
        player1.transform.position = Vector3.MoveTowards(player1.transform.position, player2.transform.position, -step * hitBackDistance);
        player2.transform.position = Vector3.MoveTowards(player2.transform.position, player1.transform.position, -step * hitBackDistance);

        //when players collide, the camera pulls out
        Camera.main.transform.position += new Vector3(0, 0, -20);

        //the stage gets bigger, and so does the radius
        goal.transform.localScale += new Vector3(80, 80, 80);
        radius += 15;

        //the players get slightly larger
        GameManagerScript.increaseSize += 1f;

        //the players get faster
        GameManagerScript.increaseSpeed += 10f;

        //speedBoost is reset
        speedUpScript.player1SpeedBoost = 1;
        speedUpScript.player2SpeedBoost = 1;

        //spawn a new speedboost
        GameObject newSonic = Instantiate(sonicPrefab, (Random.insideUnitCircle * radius), Quaternion.identity) as GameObject;


    }

    // Update is called once per frame
    void Update () {

        //Distance between center of goal and this gameObject to check to see if it's greater than the radius.
        //if the distance is greater than the radius than player controls are disbaled while the player "bounces back"
        float step = speed * Time.deltaTime;

        if (Vector3.Distance(goal.transform.position, transform.position) > radius)
        {
            bounceBack = true;
            playerControlScript.enabled = false;
        }

        if (bounceBack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, centerPoint.transform.position, step);
        }

        if (Vector3.Distance(goal.transform.position, transform.position) < radius/2f)
        {
            bounceBack = false;
            playerControlScript.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Restart");
        }

    }

}
