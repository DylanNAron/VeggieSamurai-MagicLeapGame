using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieHit : MonoBehaviour
{
    private GameObject scoreManager;
    private ScoreManager ScoreMan;

    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
        ScoreMan = (ScoreManager)scoreManager.GetComponent(typeof(ScoreManager));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Sword")
        {
        	//instantiate break effect ?
            Debug.Log("Hit");
            Destroy(gameObject, 2.0f);
            ScoreMan.IncreaseScore();
        }
        else
        {
            Debug.Log("HitFloor");
            ScoreMan.IncreaseStrikes();
        }
    } 
}
