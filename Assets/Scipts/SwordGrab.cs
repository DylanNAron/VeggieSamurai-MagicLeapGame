using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGrab : MonoBehaviour
{
	public GameObject grabSwordUI;
	public GameObject controller;
	private GameObject[] spawners;

    void Start()
    {
		spawners = GameObject.FindGameObjectsWithTag("Spawner");
		Debug.Log(spawners);
	}

	void OnTriggerEnter(Collider collider) {

		if(collider.gameObject.tag == "Sword") {
			//attach
			Debug.Log("Sword Grabbed");
			/*
			collider.gameObject.transform.parent = gameObject.transform;
			collider.gameObject.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(90, 0, 0);
			*/

			collider.gameObject.transform.parent = controller.transform;
			collider.gameObject.transform.rotation = controller.transform.rotation * Quaternion.Euler(180, 0, 0);


			//Disable UI
			grabSwordUI.SetActive(false);

			Debug.Log(spawners);
			//Start Spawners
			//spawners = GameObject.FindGameObjectsWithTag("Spawner");
			foreach (GameObject spawner in spawners)
            {
				spawner.SetActive(true);
				spawner.transform.GetChild(0).gameObject.SetActive(true);
				Debug.Log("spawner activated");
            }
		}
	}

}
