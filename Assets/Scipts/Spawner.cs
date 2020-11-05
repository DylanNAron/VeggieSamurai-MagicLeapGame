using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject vegetable;
    public float timeBtwSpawn;
    private float startTimeBtwSpawn;
    //public GameObject camera;

    public float speed;

    private void Start() {
        startTimeBtwSpawn = Time.time;
    }

    private void Update(){

    	if(startTimeBtwSpawn + timeBtwSpawn <= Time.time){

    		GameObject obj = (GameObject)Instantiate(vegetable, transform.position, Quaternion.identity);
            Vector3 dir = (Camera.main.transform.position - transform.position).normalized;
            //Vector3 dir = Vector3.forward;

            obj.GetComponentInChildren<Rigidbody>().AddForce(speed * dir, ForceMode.VelocityChange);
    		startTimeBtwSpawn = Time.time;
            //timeBtwSpawn = Mathf.Max(1f, timeBtwSpawn - 0.1f);

            //Debug.Log("spawn time: " + startTimeBtwSpawn);

    	}

    }
}
