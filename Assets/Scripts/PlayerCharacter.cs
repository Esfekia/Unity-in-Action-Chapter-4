using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;

    private void Start()
    {
        // initialize the health value
        health = 5;    
    }

    public void Hurt(int damage)
    {
        // decrement player's health
        health -= damage;

        // construct the message by using string interpolation
        Debug.Log($"Health: {health}");
    }

}
