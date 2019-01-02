using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pickups : MonoBehaviour {

    public GameObject chest;
    public Sprite OpenChest;
    public GameObject Gem;
    public GameObject player;
   

	
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
            if (player.GetComponent<PlayerControler>().GetScore() >= 2) // if the score in the player controller script is == 2 then set the chest sprite to open chest and set the gem object to true
            {
                this.GetComponent<SpriteRenderer>().sprite = OpenChest;

                Gem.SetActive(true);
            }

        }
    }

}
