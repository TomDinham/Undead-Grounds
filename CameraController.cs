using UnityEngine;
using System.Collections;

public class CameraController: MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f); //allows the camera to follow the players new x and y position 
        //the player has to be tagged to the camera 

	}
}
