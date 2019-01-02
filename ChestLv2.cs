using UnityEngine;
using System.Collections;

public class ChestLv2 : MonoBehaviour
{
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
            if (player.GetComponent<PlayerControler>().GetScore() >= 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = OpenChest;

                Gem.SetActive(true);
                //in this if statement when the player collides with the chest and has a score of 4 in the game.
                //the chest closed sprite gets replaced with chest open sprite and the crystal in the game isset to true instead of false.
            }

        }
    }

}
