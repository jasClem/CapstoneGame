using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour {

    public string playerName;
    //String variable for player name

    public GameObject scoreUI;
    public int playerScore;
    //GameObject & integer variables for Score UI & player score

    public GameObject timeUI;
    public int timePointScore = 10;
    public float timeRemaining = 300;
    //GameObject, integer & float variables for Time UI, 
    //remaining time point score & remaining level time
    
    public GameObject coinUI;
    public int coinPointScore = 5;
    public int coinCount;
    //GameObject & integer variables for Coin Count UI & coin point score

    public GameObject worldUI;
    public string levelName;
    Scene currentLevel;
    //GameObject, String & Scene variabes for current level

    public AudioSource coinSound;

    void Start () {
        playerScore = 000000;
        //Set player score to 0

        coinCount = 00;
        //Set player coin count to 0

        playerName = gameObject.name.ToUpper();
        //Get player name

        currentLevel = SceneManager.GetActiveScene();
        //Get current level scene

        levelName = currentLevel.name;
        //Get current level name

    }


    void Update () {

        timeUI.gameObject.GetComponent<Text>().text = ("TIME\n"+timeRemaining.ToString("000"));
        //Display/Update UI Time

        coinUI.gameObject.GetComponent<Text>().text = ("x" + coinCount.ToString("00"));
        //Display/Update player coin count

        worldUI.gameObject.GetComponent<Text>().text = (levelName);
        //Display/Update current level name

        scoreUI.gameObject.GetComponent<Text>().text = (playerName+"\n"+playerScore.ToString("000000"));
        //Display/Update player score

        timeRemaining -= Time.deltaTime;
        //Subtract time from remaining time
		
	}

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.name == "LevelEnd"){
            ScorePlayer();
            //If player enters level end boundry, score player
        }
        if (collision.gameObject.tag == "Coin"){

            playerScore += coinPointScore;
            //If player collides with coin, add coin points

            coinSound.Play();

            coinCount += 1;
            //Add coin to player coin count

            Destroy(collision.gameObject);
            //Destroy coin gameObject
        }
    }

    void ScorePlayer(){
        playerScore = playerScore + (int)(timeRemaining * timePointScore);
        //At end of world, add points for remaing level time

    }

   
}
