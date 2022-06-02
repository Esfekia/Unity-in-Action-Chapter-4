using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    // values for the movement speed and distance at which to react to objects
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    // serialized variable for linking to the prefab object
    [SerializeField] GameObject fireballPrefab;

    // keep track of the instance created by the code
    private GameObject fireball;

    // check if the enemy is alive
    private bool isAlive;

    private void Start()
    {
        isAlive = true;
    }
    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }
    void Update()
    {      
        // move only if the enemy is alive
        if (isAlive)
            // move forward continuously every frame, regardless of turning
            transform.Translate(0, 0, speed * Time.deltaTime);

        // a ray at the same position and pointing in the same direction as the enemy
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        
        // perform raycasting with a circular volume around the ray.
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            // detect player the same way as the target object is detected in RayShooter script
            // similar to how we created ReactiveTarget for shooting enemies, now the enemy needs PlayerCharacter script to shoot at.
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                // same null game-object logic as SceneController
                if (fireball == null)
                {
                    // same as SceneController, instantiate the prefab
                    fireball = Instantiate(fireballPrefab) as GameObject;

                    // place the fireball in front (1.5f) of the enemy and point in the same direction
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }

            }
            if (hit.distance < obstacleRange)
            {
                // turn toward a semi-random new direction
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
            
        }
    }
}
