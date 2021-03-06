﻿using System;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    bool isFocus = false;
    bool hasInteracted = false;
    Transform player;
    public Transform SPAWN;


    public virtual void Interact()
    {
        if (hasInteracted == false)
        {
            //This method is meant to be overwritten

            if (transform.name == "Cube")
            {
                UnityEngine.Debug.Log("Interacting with " + transform.name);
            }

 
            //UnityEngine.Debug.Log(SPAWN.position);
            transform.position = SPAWN.position;



            hasInteracted = true;
        }
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;

    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = true;

    }

    void OnDrawGizmosSelected()
    {
        if ((transform.name == "redFloor") || (transform.name == "Floor"))
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, new Vector3(100,3, 61));
        }
        else {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
        
    }
}
