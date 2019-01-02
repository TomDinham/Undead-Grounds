using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthChange : MonoBehaviour {
    public GameObject player;

    public Sprite[] sprites;

	
	void Start () {
	
	}
	
	
	void Update ()
    {
        this.GetComponent<Image>().sprite = sprites[player.GetComponent<PlayerControler>().Gethealth()]; //creates an arry of sprites and then sets a sprite dependent on the players health in the player controller script
	}
}
