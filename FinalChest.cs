using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FinalChest : MonoBehaviour
{

    public GameObject chest;
    public Sprite closedChest;
    public Sprite OpenChest;
    public GameObject player;
    public GameObject Cage;
    public GameObject en;
    public int score;
    public GameObject GmContr;

    void Start()
    {
        

    }


    void Update()
    {
        

    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            if (player.GetComponent<PlayerCastleClimb>().GetScore() >= 3)
            {
                score = 4;
                this.GetComponent<SpriteRenderer>().sprite = OpenChest;
                Cage.GetComponent<Animation>().Play("CageAni");
                Cage.GetComponent<AudioSource>().Play();
               //as the player is climbing in level 6 he will need to grab the crystals
               //to get his score to 4 before trying to save his friend and opening the chest 
               //if the players score is equal to
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = closedChest;
                en.GetComponent<AudioSource>().Play();
                en.GetComponent<Animation>().Play("Move");
                Destroy(GmContr);
            }

        }
    }
    public int GetScore()
    {
        return score;
    }

}
