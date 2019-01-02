using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControler : MonoBehaviour

{
    public AudioSource Walk;
    public Rigidbody2D Rig;
    bool isWalking;
    public float Move = 10f;
    public Sprite george1;
    public Sprite george2;
    public Sprite george3;
    public Sprite geroge8;
    private SpriteRenderer MySpriteRenderer;
    public Text Health;
    private int health;
    private int diff;
    public GameObject player;
    public GameObject Key1;
    public GameObject Key1Im;
    public GameObject Key2Im;
    public GameObject Key2;
    public GameObject Key3;
    public GameObject Key3Im;
    public GameObject Key4Im;
    public GameObject Key4;
    private int score;
    public GameObject Gem;
    public GameObject GemIm;
    public GameObject Door;
    public GameObject TrapIm;
    public GameObject Cloud;
    public GameObject Help;
    public GameObject GemFake;
    public GameObject GhostDeath;
  

    public bool movingRight, movingLeft, movingUp, movingDown;
 




    void Start()
    {
        MySpriteRenderer = GetComponent<SpriteRenderer>();// giving my sprite renderer the players spriterenderer
        Rig = player.GetComponent<Rigidbody2D>();// giving rig the players ridged body
        Walk = player.GetComponent<AudioSource>();//giving walk the players audio source
        isWalking = false;//setting the bool of is walking to false
        health = 4;// setting the players health to 4

        movingDown = false;// setting the bool to false
        movingUp = false;// setting the bool to false
        movingLeft = false;// setting the bool to false
        movingRight = false;// setting the bool to false
    }

    public void startLeft()
    {
        movingLeft = true;// setting the bool to True when start left is called
    }
    public void stopLeft()
    {
        movingLeft = false;// setting the bool to false when stop left is called
    }
    public void startRight()
    {
        movingRight = true;// setting the bool to true when start right is called
    }
    public void stopRight()
    {
        movingRight = false;// setting the bool to false when stop right is called
    }
    public void startUp()
    {
        movingUp = true;// setting the bool to true when start up is called
    }
    public void stopUp()
    {
        movingUp = false;// setting the bool to false when stop up is called
    }
    public void startDown()
    {
        movingDown = true;// setting the bool to true when start down is called
    }
    public void stopDown()
    {
        movingDown = false;// setting the bool to false when stop down is called
    }

    void Update()
    {
        isWalking = false;
        if (movingRight) 
        {
            WalkRight(); //if the player is moving right then call walkright 

        }
        if (movingLeft)
        {
            WalkLeft();//if the plater is walking left then call walk left

        }
        if (movingUp)
        {
            WalkUp();//if the player is walking up call walkup

        }
        if (movingDown)
        {
            WalkDown();//if the player is walking down call walk down

        }

        Health.GetComponent<Text>().text = health.ToString();
        if (isWalking == true)
        {
            footsteps();//if iswalking is true then call the function footsteps

        }
        if (isWalking == false)
        {
            StopFootSteps(); //if iswalking is false then call the function stopfootsteps
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Skel")// of the player collides with skel
        {
            health--;// - 1 health
            if (health < 0)
            {
                Destroy(player.gameObject); //if the players health is less than 0 then destroy the player and set trapim as 0
                TrapIm.SetActive(true);
            }
        }
        if (col.gameObject.tag == "Key1") //if the player collides with key1
        {
            score++;
            Destroy(Key1.gameObject); // add 1 to score, destroy the key object and set the image to true
            Key1Im.SetActive(true);
            
        }
        if (col.gameObject.tag == "Key2")//if the player collides with key2
        {
            score++;
            Destroy(Key2.gameObject);// add 1 to score, destroy the key object and set the image to true
            Key2Im.SetActive(true);
        }
        if (col.gameObject.tag == "Key3")//if the player collides with key3
        {
            score++;
            Destroy(Key3.gameObject);// add 1 to score, destroy the key object and set the image to true
            Key3Im.SetActive(true);

        }
        if (col.gameObject.tag == "Key4")//if the player collides with key4
        {
            score++;
            Destroy(Key4.gameObject);// add 1 to score, destroy the key object and set the image to true
            Key4Im.SetActive(true);

        }
        if (col.gameObject.tag == "Gem")
        {
            Destroy(Gem.gameObject);
            GemIm.SetActive(true);
            Destroy(Door.gameObject); // if the player collides with the gem game object, then desroy the gem, set the gem image to active and destroy the cloud and door.
            Destroy(Cloud.gameObject);
        }
        if (col.gameObject.tag == "Cloud")
        {
            Help.SetActive(true); //if the player collides with the cloud then set help to active
        }
        if (col.gameObject.tag == "Fake")
        {
            health--; //if the player collides with fake then take 2 from the health and destroy the fake object
            health--;
            Destroy(GemFake.gameObject);
        }
        if(col.gameObject.tag == "Health")
        {
            diff = 4 - health;
            health += diff; //if the player collides with health then restore the players health to full and destroy the health pad
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag=="Water")
        {
            health -= 2;
            Destroy(col.gameObject); // if the player collides with water then - 2 from healtha and destroy the water
            if (health < 0)
            {
                Destroy(player.gameObject); //if the players health is less than 0 then destroy the player and set trap im to true
                TrapIm.SetActive(true);
            }
        }
        if(col.gameObject.tag=="Bear")
        {
            health -= 1; //if the player collides with Bear then -1 from health and start slow coroutine
            StartCoroutine(slow());
            if (health < 0)
            {
                Destroy(player.gameObject); //if the players health is less than 0 then destroy the player and set trap im to true
                TrapIm.SetActive(true);
            }
        }
        if(col.gameObject.tag=="Ghost")
        {
            health -= 2; //if the player collides with the ghost then -2 from health 
            if (health<0)
            {
                Destroy(player.gameObject);//if the players health is less than 0 then destroy the player and set trap im to true
                GhostDeath.SetActive(true);
            }

        }

    }
    void OnTriggerExit2D(Collider2D Ex)
    {
        if (Ex.gameObject.tag == "Cloud") // when the player leaves the cloud collider then set help to false
        {
            Help.SetActive(false);
        }
    }

    public int Gethealth()
    {
        return health;// return the health int if Gethealth is called
    }
    public int GetScore()
    {
        return score;// return the score int if Getscore is called
    }
    private IEnumerator slow()
    {
        Move =5f;
        yield return new WaitForSeconds(5f); //set the players speed top 5, waith 5 seconds, then set it back to 15
        Move = 15f;
    }
    void StopFootSteps()
    {
        Walk.Pause();//stop playing walk
    }
    void footsteps()
    {
        if (!Walk.isPlaying)
        {
            Walk.loop = true;// if walk is not playing, play it.
            Walk.Play();
        }

    }
    public void WalkRight()
    {
        
            transform.Translate(Vector3.right * Move * Time.deltaTime);
            MySpriteRenderer.sprite = george1;// move the player right and set the sprite to the given sprite, set iswalking to true
        isWalking = true;

    }
    public void WalkLeft()
    {
        transform.Translate(Vector3.left * Move * Time.deltaTime);
        MySpriteRenderer.sprite = george3;// move the player right and set the sprite to the given sprite, set iswalking to true
        isWalking = true;

    }
    public void WalkUp()
    {
        transform.Translate(Vector3.up * Move * Time.deltaTime);
        MySpriteRenderer.sprite = george2;// move the player up and set the sprite to the given sprite, set iswalking to true
        isWalking = true;
    }
    public void WalkDown()
    {
        transform.Translate(Vector3.down * Move * Time.deltaTime);
        MySpriteRenderer.sprite = geroge8; // move the player down and set the sprite to the given sprite, set iswalking to true
         isWalking = true;
    }
}





