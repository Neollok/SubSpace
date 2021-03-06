﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_Guard : MonoBehaviour {

    // Add code for walking right and/or left
    // Make sure correct values are used for this!
    // Left_PR_Right & Transision

    public float speed = 0.08f;
    bool movingLeft;
    bool moving;
    int timeGoing = 0;

    Animator simpleGuard_Animator;
    Rigidbody2D Simple_GuardRB;



	// Use this for initialization
	void Start () {
        simpleGuard_Animator = GetComponent<Animator>();
        Simple_GuardRB = GetComponent<Rigidbody2D>();
        movingLeft = Random.Range(0,1) == 0; // desides if mob starts going to the left or right
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Simple_GuardRB.velocity.y >= -0.2f)
            UpdatePosision();
    }

    void UpdatePosision() // Code for updating animation and celocity of enemy
    {
        if (Simple_GuardRB.velocity == new Vector2(0, 0) && timeGoing < 180)
            moving = false; // Entity has been stopped
        
        if (timeGoing >= 150)
        {
            simpleGuard_Animator.SetTrigger("Transision");
            if (timeGoing >= 180)
            {
                moving = true;
                movingLeft = !movingLeft;
                timeGoing = 0;
            }
        }

        if (moving)
        {
            if (movingLeft)
                Simple_GuardRB.velocity += new Vector2(-speed, 0.0f);
            else
                Simple_GuardRB.velocity += new Vector2(speed, 0.0f);
        }
        else
        {
            timeGoing++;
            simpleGuard_Animator.SetBool("Left_Or_Right", movingLeft);
        }
    }
}
