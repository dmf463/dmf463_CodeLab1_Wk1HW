using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {

    //MonoBehaviour is a base type of scripts that lets us attach scripts to game objects.
   
    // Use this for initialization, called once at the beginning.

    public float speed;

    //allows you to choose the KeyCode in the inspector
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;



    void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
        
        //Move the Player
        Move(Vector3.up, upKey);
        Move(Vector3.down, downKey);
        Move(Vector3.left, leftKey);
        Move(Vector3.right, rightKey);

        //if (Input.GetKey(KeyCode.W))
        //{
        //    //Debug.Log("This is Working");
        //    transform.Translate(Vector3.up * speed * Time.deltaTime); 
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    //Debug.Log("This is Working");
        //    transform.Translate(Vector3.down * speed * Time.deltaTime);
        //}

    }

    void Move(Vector3 dir, KeyCode key)
    {
        if(Input.GetKey(key))
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }

}
