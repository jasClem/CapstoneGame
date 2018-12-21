using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour {

    public int enemySpeed;
    //Integer variabe for enemy speed

    public int controlX;
    //Integer variable to control enemy (left = -1) or (right = 1) movement

    public bool facingRight;
    //Boolean variable to determine if enemy is facing right (or left)

    public float hitcheck;
    //Float integer to check enemy hit distance

    public float enemySideOffset = 0.49f;

    public bool playerDead;


	void Start () {
        playerDead = false;
		
	}
	

	void Update () {

        RaycastHit2D hitSide = Physics2D.Raycast(transform.position, new Vector2(controlX, 0));
        //Check RaycastHit of enemy horozontally


        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(controlX, 0) * enemySpeed;
        //Move ememy

        hitcheck = hitSide.distance;
        //Set/check current hit distance

        if (hitSide.distance < enemySideOffset)
        {

            if (hitSide.collider.GetComponent<BoxCollider2D>().tag == "Player")
            {
                //hitSide.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 800);
                //hitSide.collider.GetComponent<BoxCollider2D>().enabled = false;
                //hitSide.collider.GetComponent<PlayerController>().enabled = false;

                if (!playerDead)
                {
                    hitSide.collider.GetComponent<PlayerHealth>().isDead = true;
                    playerDead = true;

                }

            }
            else
            {

            }

            SpriteFlipper();

        }

    }

    private void SpriteFlipper()
    {
        if (controlX > 0){
            controlX = -1;
        }else {
            controlX = 1;
        }
        //Flip movement left or right when hitting walls

        /*
        facingRight = !facingRight;
        //Change bool for facing left or right

        Vector2 localScale = gameObject.transform.localScale;
        //Vector2 variable for enemy's localScale

        localScale.x *= -1;
        //Invert enemy's X localScale

        transform.localScale = localScale;
        //Apply inverted localScale to enemy/sprite
        */
    }
}
