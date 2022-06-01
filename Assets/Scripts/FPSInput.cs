using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;

    // variable for referencing the CharacterController
    private CharacterController charController;

    private void Start()
    {
        // access the CharacterController attached to this object
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // horizontal and vertical are indirect names for keyboard mappings
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // limit diagonal movement to the same speed as movement along an axis
        movement = Vector3.ClampMagnitude(movement, speed);

        // use gravity value

        movement.y = gravity;

        movement *= Time.deltaTime;

        // transform the movement vector from local to gloval coordinates
        movement = transform.TransformDirection(movement);

        // tell the CharacterController to move by that vector
        charController.Move(movement);
              
                
    }
}
