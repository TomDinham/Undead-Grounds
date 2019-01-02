using UnityEngine;
using System.Collections;

public class FallingBlock : MonoBehaviour {

    
    void Start ()
    {
	
	}
	
	
	void Update ()
    {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Player")
        {
            StartCoroutine(FallBlock());
            //if the player collides with certain blocks in level 6 they will start aco routine called fallblock
        }
    }
    IEnumerator FallBlock()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        //after the fallblock routine isfinished it waits 1 second before destroying the block object 
    }
}
