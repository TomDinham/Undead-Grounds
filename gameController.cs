using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
public class gameController : MonoBehaviour
{
    public GameObject player;
    public GameObject image;
    public GameObject heart;
    public GameObject text;
    public Button start;
    public GameObject Restartbut;
    

    void Start()
    {

    }


    void Update()
    {
        if (player==null)
        {
            image.SetActive(true);
            Destroy(heart.gameObject); // if the players object gets destroyed then heart and text objects get destroyed and image and restart become active.
            Destroy(text.gameObject);
            Restartbut.SetActive(true);
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene("Level 1"); // loads level 1 on call.
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1"); // loads level 1 on call.
    }
    public void lvl2()
    {
        SceneManager.LoadScene("Level 2");// loads level 2 on call.
    }
    public void lvl3()
    {
        SceneManager.LoadScene("Garden");// loads level Garden on call.
    }
    public void lvl4()
    {
        SceneManager.LoadScene("Graveyard");// loads level Graveyard on call.
    }
    public void lvl5()
    {
        SceneManager.LoadScene("Outside stone level");// loads level Outside stone level on call.
    }
    public void lastlvl()
    {
        SceneManager.LoadScene("FinalLevel");// loads level final level on call.
    }
}

