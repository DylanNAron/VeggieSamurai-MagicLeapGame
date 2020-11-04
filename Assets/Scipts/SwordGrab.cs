using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGrab : MonoBehaviour
{
	public GameObject grabSwordUI;
	public GameObject controller;
	private GameObject[] spawners;

	void OnTriggerEnter(Collider collider) {

		if(collider.gameObject.tag == "Sword") {
			//attach
			Debug.Log("Sword Grabbed");
			collider.gameObject.transform.parent = gameObject.transform;
			collider.gameObject.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 0, 0);
			//Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);



			//Disable UI
			grabSwordUI.SetActive(false);


			//Start Spawners
			spawners = GameObject.FindGameObjectsWithTag("Spawners");
			foreach(GameObject spawner in spawners)
            {
				spawner.SetActive(true);
            }
		}
	}

}
