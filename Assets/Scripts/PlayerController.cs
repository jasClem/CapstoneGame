using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public string playerName;
    //String variable for player name

    public int marioSpeed = 10;
    public int marioJump = 1250;
    //Integer variables for player's speed & jump power

    public bool facingRight = true;
    //Bool variable to flip sprite left/right

    public bool onGround;
    //Bool variable for player being on the ground

    private float controlX;
    public float currentSpeed;
    //Float variable to get horizontal player controls

    public float hitcheck;
    public bool hitObjectDown;
    //Float integer & bool to check enemy hit distance/check hits

    public float fallMultiplyer = 2.5f;
    public float lowJumpMultiplyer = 2f;

    public float playerDownOffset = 1.1f;

    public AudioSource marioJumpSound;

    public AudioSource stompSound;



    void Start()
    {
        onGround = false;
        //Set ground bool (player should not start level on ground)

        playerName = gameObject.name;
        //Get player name
    }


    void Update() {

        PlayerRaycast();

        PlayerMovement();
        //Get controls/Move player
    }



    void PlayerMovement() {

        controlX = Input.GetAxis("Horizontal");
        //Get <- & -> controls

        currentSpeed = (controlX * marioSpeed);

        GetComponent<Animator>().SetFloat("currentSpeed", currentSpeed);

        if (Input.GetButtonDown("Jump")){
            //Get jump button input

            if (onGround){
                Jump();
                //If player is grounded, make player jump
            }
        }

        if (controlX > 0.0f && facingRight == false) {
            //Flip player sprite left

            GetComponent<SpriteRenderer>().flipX = false;
            facingRight = !facingRight;

        } else if (controlX < 0.0f && facingRight == true) {
            //Flip player sprite right

            GetComponent<SpriteRenderer>().flipX = true;
            facingRight = !facingRight;
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(currentSpeed,
            gameObject.GetComponent<Rigidbody2D>().velocity.y);
        //Move Mario's Rigidbody2D based on controls & speed
    }



    void Jump(){

        GetComponent<Rigidbody2D>().AddForce(Vector2.up * marioJump);
        //Apply jump force to player Rigidbody2D based on jump power

        marioJumpSound.Play();

        GetComponent<Animator>().SetBool("onGround", false);
        onGround = false;
        //Switch ground bool
    }


    void PlayerRaycast(){
        RaycastHit2D hitBelow = Physics2D.Raycast(transform.position, Vector2.down * 25);
        //Get RaycastHit for things under player

        if (hitBelow && hitBelow.collider != null){

            hitcheck = hitBelow.distance;

            if (hitBelow.distance < playerDownOffset){

                if (hitBelow.collider.tag == "Enemy")
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
                    //Make player bounce up off enemy

                    stompSound.Play();

                    GetComponent<ScoreSystem>().playerScore += 25;

                    hitBelow.collider.GetComponent<Animator>().SetBool("isDead", true);
                    hitBelow.collider.GetComponent<BoxCollider2D>().enabled = false;
                    hitBelow.collider.GetComponent<Rigidbody2D>().AddTorque(45f);
                    hitBelow.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
                    hitBelow.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
                    hitBelow.collider.GetComponent<Rigidbody2D>().freezeRotation = false;
                    hitBelow.collider.GetComponent<GoombaController>().enabled = false;
                    //Destroy(hitBelow.collider.gameObject);
                }

                if (hitBelow.collider.tag != "Enemy")
                {
                    GetComponent<Animator>().SetBool("onGround", true);
                    onGround = true;
                    //gameObject.GetComponent<AnimationState>().setBool
                }
            }

            
        }
    }
}
