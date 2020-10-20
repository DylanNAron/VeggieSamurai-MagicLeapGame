using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGrab : MonoBehaviour
{

	public GameObject controller;

	void OnTriggerEnter(Collider collider) {

		if(collider.gameObject.tag == "Sword") {
			//attach
			Debug.Log("Sword Grabbed");
			collider.gameObject.transform.parent = gameObject.transform;
			collider.gameObject.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180, 0);
			//Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
		}
	}

}
