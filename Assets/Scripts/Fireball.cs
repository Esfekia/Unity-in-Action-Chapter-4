using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;
    void Update()
    {
        // move forward in the direction it faces.
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    // called when another object collides with this trigger    
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        
        // check if the other object is a PlayerCharacter
        if (player != null)
        {
            player.Hurt(damage);
        }
        Destroy(this.gameObject);              
    }
}
