using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Sword")
        {
        	//instantiate break effect ?
            Debug.Log("Hit");
            Destroy(gameObject, 2.0f);
        }
    } 
}
