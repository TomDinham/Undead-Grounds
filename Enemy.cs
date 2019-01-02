using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public GameObject Death;
    public GameObject restart;
    public GameObject Menu;
    public GameObject player;

	void Start ()
    {
	
	}
	
	

	void Update ()
    {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            Destroy(player.gameObject);
            Death.SetActive(true);
            restart.SetActive(true);
            Menu.SetActive(true);
            //if the player comes into contact with the reaper the player will be destroyed 
            //and activate relevant menus and buttons for when the player dies
        }
    }
}
