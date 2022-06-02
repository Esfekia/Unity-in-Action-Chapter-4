using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        // lock mouse and hide mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
        
    void Update()
    {
        // respond to the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // use the center of the screen which is half its width and height
            Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);

            // create the ray at that position by using ScreenPointToRay()
            Ray ray = cam.ScreenPointToRay(point);

            RaycastHit hit;
            
            // fill a referenced variable with information from the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // retrieve the object the ray hit
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                
                // check for the ReactiveTarget component on the object
                if (target != null)
                {
                    // call a method of the target
                    target.ReactToHit();
                    
                    // display on console that target was hit
                    Debug.Log("Target hit!");
                }
                else
                {
                    // launch a coroutine in response to a hit
                    StartCoroutine(SphereIndicator(hit.point));
                }
                

            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        // create a sphere at pos
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        // the yield keyword tells coroutines where to pause
        yield return new WaitForSeconds(1);

        // destroy the sphere after 1 seconds
        Destroy(sphere);
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        // display text on screen through GUI.Label()
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
