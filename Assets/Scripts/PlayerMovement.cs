﻿using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask wallMask;
    public float jumpHeight = 3f;
    bool isGroundedSphere;
    float gracePeriod = 0.2f;
    float groundedTimer = 0;
    float jumpTimer=0;
    float wallGracePeriod = 0.7f;
    float nextJump;
    public GameObject anim;
    float animationCd = 0;
    float animationRate = 0.12f;
    

    float jumpSoundTimer = 0;
    float jumpSoundGracePeriod = 0.1f;
    float walkSoundTimer = 0;
    float walkSoundGracePeriod = 0.4f;

    bool IsGrounded { get { return groundedTimer > 0; } }

    private void Start()
    {
        anim.GetComponent<Animation>().wrapMode = WrapMode.Loop;
    }
    void Update()
    {
        isGroundedSphere = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //gracePeriod
        if (isGroundedSphere)
        {
            groundedTimer = gracePeriod;
        }
        else if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime;
        }
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        //move
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move.normalized * speed * Time.deltaTime);

        //Animations
        
        if (animationCd < 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.GetComponent<Animation>().CrossFade("Shoot");
                animationCd = animationRate;
            }
            else if (GetComponent<CharacterController>().velocity.magnitude > 0 && isGroundedSphere)
            {
                anim.GetComponent<Animation>().CrossFade("Walk");
                if (Time.time > walkSoundTimer)
                {
                    walkSoundTimer = Time.time + walkSoundGracePeriod;
                    SoundManagerScript.PlaySound("Walk");
                }
            }
            else
            {
                anim.GetComponent<Animation>().CrossFade("Idle");
            }
        }
        animationCd -= Time.deltaTime;

        //jump
        if (jumpTimer > 0)
        {
            CheckForWall();
            jumpTimer -= Time.deltaTime;
            Quaternion tilt = transform.rotation;
            Vector3 euler = transform.rotation.eulerAngles;
            if (isWallLeft)
            {
                tilt = Quaternion.Euler(euler.x, euler.y, -10);
            }
            else if (isWallRight)
            {
                tilt = Quaternion.Euler(euler.x, euler.y, 10);

            }
            transform.rotation = Quaternion.Lerp(transform.rotation, tilt, 0.1f);
        }
        else
        {
            Vector3 euler = transform.rotation.eulerAngles;
            Quaternion upright = Quaternion.Euler(euler.x, euler.y, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, upright, 0.1f);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                groundedTimer = 0;
                if (Time.time > jumpSoundTimer)
                {
                    jumpSoundTimer = Time.time + jumpSoundGracePeriod;
                    SoundManagerScript.PlaySound("Jump");
                }
            }
            else if (jumpTimer > 0 )
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                jumpTimer = 0;
                jumpFromWall = true;
                if (Time.time > jumpSoundTimer)
                {
                    jumpSoundTimer = Time.time + jumpSoundGracePeriod;
                    SoundManagerScript.PlaySound("Hydraulic");
                }
            }
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    //wall Jump
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.name == "FallingPlatform") Destroy(hit.gameObject,1f);
        if (hit.gameObject.layer == 10)
        {
            if (!controller.isGrounded && hit.normal.y < 0.1f)
            {
                if (lastWall == null || !jumpFromWall || lastWall != hit.transform)
                {
                    jumpTimer = wallGracePeriod;
                    lastWall = hit.transform;
                    jumpFromWall = false;
                }
            }
        }
        if (controller.isGrounded)
        {
            lastWall = null;
        }
    }
    Transform lastWall;
    bool jumpFromWall = false;
    bool isWallRight=false;
    bool isWallLeft=false;
    private void CheckForWall() //make sure to call in void Update
    {
        isWallRight = Physics.Raycast(transform.position, transform.right, 1f, wallMask);
        isWallLeft = Physics.Raycast(transform.position, -transform.right, 1f, wallMask);
    }

}
