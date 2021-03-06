﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsUI : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject spawners;
    //private AsyncOperation sceneAsync;

    public GameObject spawnerUI;
    public GameObject spawnerRaycastvisualizer;

    private GameObject[] spawners;


    public void SpawnerPlaceStart()
    {
        Debug.Log("Start");
        //StartCoroutine(loadScene(1));
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            Destroy(spawner);
            Debug.Log("Spawners destroyed");
        }

    }

    /*

    IEnumerator loadScene(int index)
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;
        sceneAsync = scene;

        //Wait until we are done loading the scene
        while (scene.progress < 0.9f)
        {
            Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
            yield return null;
        }
        OnFinishedLoadingAllScene();
    }

    void OnFinishedLoadingAllScene()
    {
        Debug.Log("Done Loading Scene");
        enableScene(1);
        //SceneManager.UnloadScene(0);
        Debug.Log("Scene Activated!");
       // spawnerUI.SetActive(false);
        //spawnerRaycastvisualizer.SetActive(false);
    }

    void enableScene(int index)
    {
        //Activate the Scene
        sceneAsync.allowSceneActivation = true;


        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
        if (sceneToLoad.IsValid())
        {
            Debug.Log("Scene is Valid");
            SceneManager.MoveGameObjectToScene(spawners, sceneToLoad);
            SceneManager.SetActiveScene(sceneToLoad);
            SceneManager.UnloadScene(0);
        }
    }

    */
}
