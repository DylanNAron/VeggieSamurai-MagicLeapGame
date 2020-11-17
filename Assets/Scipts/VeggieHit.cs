using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieHit : MonoBehaviour
{
    private GameObject scoreManager;
    private ScoreManager ScoreMan;
    public GameObject veggieExplosion;

    private bool IsTriggered = false;

    AudioSource VeggieSound;

    private void Start()
    {
        VeggieSound = GetComponent<AudioSource>();
        scoreManager = GameObject.Find("ScoreManager");
        ScoreMan = (ScoreManager)scoreManager.GetComponent(typeof(ScoreManager));
    }

    /*
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Sword")
        {
        	//instantiate break effect ?
            Debug.Log("Hit");
            Destroy(gameObject, 2.0f);
            ScoreMan.IncreaseScore();
            Instantiate(veggieExplosion);
        }
        else
        {
            Debug.Log("HitFloor");
            ScoreMan.IncreaseStrikes();
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (IsTriggered == false)
        {
            if (other.gameObject.tag == "Sword")
            {
                //instantiate break effect ?
                Debug.Log("Hit");
                Destroy(gameObject, 2.0f);
                ScoreMan.IncreaseScore();
                Instantiate(veggieExplosion, this.gameObject.transform.position, Quaternion.identity);
                VeggieSound.Play();
            }
            else
            {
                Debug.Log("HitFloor");
                ScoreMan.IncreaseStrikes();
            }
            IsTriggered = true;
        }
    }
}
