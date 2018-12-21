using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public string playerName;
    //String variable for playerName (Mario/Luigi/Etc)

    public int health;
    //Integer variable for player health (1 or 2 depending on size)

    public bool isDead;
    //Boolean variable for alive/dead

    public string levelName;
    Scene currentLevel;
    //String & Scene variabes for current level

    public float deathWait = 3f;
    //death timer

    public AudioSource marioDiesSound;

    public AudioSource mainMusic;

    public bool fallDeath;

    
    

	void Start () {

        health = 1;

        playerName = gameObject.name;
        //Get player name (Mario/Luigi/Etc)

        currentLevel = SceneManager.GetActiveScene();
        //Get current level scene

        levelName = currentLevel.name;
        //Get current level name

        isDead = false;
        //Set player to alive (not isDead)

        fallDeath = false;

        mainMusic.Play();
		
	}

	

	void Update () {

        if (!isDead)
        {
            if (gameObject.transform.position.y <= -6.5 && fallDeath != true)
            {
                //If player goes below screen boundry

                fallDeath = true;

                isDead = true;

            }

            if (GetComponent<ScoreSystem>().timeRemaining <= 0)
            {
                isDead = true;
            }

            if (health <= 0)
            {
                //Kill player if health 0 or lower
                isDead = true;
            }

        }
        
        if (isDead)
        {

            

            StartCoroutine(KillPlayer());


            Debug.Log("KillPlayer(); Should be running");
        }
	}


    IEnumerator KillPlayer()
    {
        if (isDead)
        {
            marioDiesSound.Play();

            this.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 800);

            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<PlayerController>().enabled = false;

            Debug.Log(playerName + " has died");
            //Debug message for player death

            isDead = false;

        }

        

        mainMusic.Stop();

        GetComponent<Animator>().SetBool("isDead", true);
        //Set player to animation bool to dead

        yield return new WaitForSeconds(deathWait);
        //Wait for death timer

        SceneManager.LoadScene(levelName);
        //Load current level
    }
}
