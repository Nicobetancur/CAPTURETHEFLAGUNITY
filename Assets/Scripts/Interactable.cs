using System;
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
        //This method is meant to be overwritten
        UnityEngine.Debug.Log("Interacting with " + transform.name);
        
        if (transform.name == "Player")
        {

            transform.position = SPAWN.position;
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
        hasInteracted = false;

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
