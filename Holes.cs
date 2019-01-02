using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Holes : MonoBehaviour
{
   
    public GameObject Fall;
    public GameObject RestartBut;

	
	void Start ()
    {
	
	}
	
	
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Fall.SetActive(true);  //if the place collides with the hole object, kill the player and set fall and restart to true
            RestartBut.SetActive(true);
           

        }
            

                

    }
}
