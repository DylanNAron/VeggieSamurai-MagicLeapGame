using System.Collections;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class RaycastSpawners : MonoBehaviour
{
    private bool bumpPressed = false;
    public Transform ctransform; // Controllers transform
    public GameObject prefab;    // Cube prefab
    private MLInput.Controller _controller;


    // Use this for initialization
    void Start()
    {
        MLRaycast.Start();

        MLInput.Start();
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnControllerButtonUp += OnButtonUp;
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }

    // Update is called once per frame
    void Update()
    {
        // Create a raycast parameters variable
        MLRaycast.QueryParams _raycastParams = new MLRaycast.QueryParams
        {
            // Update the parameters with our Camera's transform
            Position = ctransform.position,
            Direction = ctransform.forward,
            UpVector = ctransform.up,
            // Provide a size of our raycasting array (1x1)
            Width = 1,
            Height = 1
        };
        // Feed our modified raycast parameters and handler to our raycast request
        MLRaycast.Raycast(_raycastParams, HandleOnReceiveRaycast);
    }
    private void OnDestroy()
    {
        MLRaycast.Stop();

        MLInput.OnControllerButtonDown -= OnButtonDown;
        MLInput.OnControllerButtonUp -= OnButtonUp;
        MLInput.Stop();
    }
    // Instantiate the prefab at the given point.
    // Rotate the prefab to match given normal.
    // Wait 2 seconds then destroy the prefab.
    private IEnumerator NormalMarker(Vector3 point, Vector3 normal)
    {
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
        GameObject go = Instantiate(prefab, point, rotation);
        yield return new WaitForSeconds(2);
        //Destroy(go);
    }

    // Use a callback to know when to run the NormalMaker() coroutine.
    void HandleOnReceiveRaycast(MLRaycast.ResultState state, UnityEngine.Vector3 point, Vector3 normal, float confidence)
    {
        if (state == MLRaycast.ResultState.HitObserved)
        {
            //StartCoroutine(NormalMarker(point, normal));
            if(bumpPressed == true)
            {
                StartCoroutine(NormalMarker(point, normal));
                bumpPressed = false;
            }
        }
    }

    void OnButtonDown(byte controllerId, MLInput.Controller.Button button)
    {
        if (button == MLInput.Controller.Button.Bumper)
        {
            bumpPressed = true;
        }

    }

    void OnButtonUp(byte controllerId, MLInput.Controller.Button button)
    {
        if (button == MLInput.Controller.Button.Bumper)
        {
            bumpPressed = false;
        }

        // When the prefab is destroyed, stop MLWorldRays API from running.
    }
}