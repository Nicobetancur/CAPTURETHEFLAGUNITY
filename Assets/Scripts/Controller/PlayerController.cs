using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(PlayerMotor))]

//NEW SCENE


public class PlayerController : MonoBehaviour
{
    public float lookRadius = 25f;
    public float enemyDist = 10f;
    Transform target;
    Transform enemytarg;
    NavMeshAgent agent;


    public Interactable focus;
    //public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;



    void Start()
    {
        enemytarg = PlayerManager.instance.enemy.transform;
        target = PlayerManager.instance.flag.transform;
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);
        float endist = Vector3.Distance(enemytarg.position, transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //UnityEngine.Debug.Log("We hit" + hit.collider.name + " " + hit.point);
                //Move Player
                motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }

        if (distance <= lookRadius)
        {
            UnityEngine.Debug.Log("IN RANGE");
            Interactable interactable = target.GetComponent<Interactable>();

            if (interactable != null)
            {
                SetFocus(interactable);
            }
        }

    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);

    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        motor.StopFollowingTarget();
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
