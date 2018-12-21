using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float xMin;
    public float xMax;
    //Public Float variables min/max X boundry (horizontal)

    public float yMin;
    public float yMax;
    //Public Float variables min/max Y boundry (vertical)

    private GameObject player;
    //GameObject variable for player
    
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        //Locate player GameObject
		
	}
	

	void Update () {

        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.x, yMin, yMax);
        //Get x & y position of player

        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        //Move camera to follow player
    }


}
