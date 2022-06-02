using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // serialized variable for linking to the prefab object
    [SerializeField] GameObject enemyPrefab;
        
    // private variable to keep track of the enemy instances in the scene
    private GameObject enemy;
    
    // Update is called once per frame
    void Update()
    {
                
        // spawn new enemy only of one isn't already in the scene
        if (enemy == null)
        {
            // method that copies the prefab object
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = new Vector3(-5, 15, 0);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }

    }
}
