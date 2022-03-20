using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseMovement : MonoBehaviour
{
    public Rigidbody Prb;
    public float Movespeed = 10f;

    private float xInput;
    private float zInput;


    private void Awake()
    {
        //Getting player's Rigidbody using on awake function as this gets called as the game is loading
        Prb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Calling PlayerInputs
        PlayerInputs();
    }

    //Using FixedUpdate as this function is better when handling physics based movement
    private void FixedUpdate()
    {
        //Calling Movement
        Movement();
    }

    private void PlayerInputs()
    {
        //Using Unity's built in axis so player can move around using the arrow keys or WASD depending on preference
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Movement()
    {
        //Using add force for player's movement and multiplying this by player's movespeed
        Prb.AddForce(new Vector3(xInput, 0f, zInput) * Movespeed);
    }
}
