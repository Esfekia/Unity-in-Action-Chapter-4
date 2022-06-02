using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    public float speed = 3.0f;
    
    // positions that the object moves between
    public float maxZ = 16.0f;
    public float minZ = -16.0f;

    // direction the object is currently moving in?
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, direction * speed * Time.deltaTime);

        bool bounced = false;

        // toggle the direction back and forth
        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            direction = -direction;
            bounced = true;
        }
        if (bounced)
            transform.Translate(0, 0, direction * speed * Time.deltaTime);
        
    }
}
