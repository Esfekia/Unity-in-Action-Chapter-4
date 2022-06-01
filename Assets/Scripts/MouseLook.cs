using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // define an enum data structure to associate names with settings
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }
    
    // declare a public variable to set in Unity's editor
    public RotationAxes axes = RotationAxes.MouseXandY;

    // horizontal look sensitivity
    public float sensitivityHor = 9.0f;

    //vertical look sensitivity and limits
    public float sensitivityVert = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    //declare a private variable for the vertical angle
    private float verticalRot = 0;
    

    void Start()
    {
        
        // To ensure player is not affected by other physics simulation of the game
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            // horizontal rotation, using GetAxis() to get mouse input
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }

        else if (axes == RotationAxes.MouseY)
        {
            // vertical rotation here
            // increment the vertical angle based on the mouse
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;

            // clamp the vertical angle between min and max limits
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            // keep the same Y angle (i.e. no horizontal rotation)
            float horizontalRot = transform.localEulerAngles.y;

            // create a new vector from the stored rotation values

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }

        else
        {
            // increment the vertical angle based on the mouse
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;

            // clamp the vertical angle between min and max limits
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            // delta is the amount to change the rotation by
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;

            // increment the rotation angle by delta
            float horizontalRot = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }
}
