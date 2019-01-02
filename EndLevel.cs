using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject cont;
    public GameObject menu;
    public GameObject cong;
    public GameObject cred;

    public void ClickDat()
    {                        //setting game objects true and false, true when they are called and false when they are finished within game.
        cont.SetActive(false);
        menu.SetActive(true);
        cong.SetActive(false);
        cred.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Menu");
    }

}
