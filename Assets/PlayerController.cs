using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(GameState))]
[RequireComponent(typeof(RunAwayController))]


public class PlayerController : MonoBehaviour
{
    
    public Transform enemytarg;
    UnityEngine.AI.NavMeshAgent agent;
    public Transform runaway;
    PlayerMotor motor;
    RunAwayController runawayObj;
    Interactable focus;
    public Transform SPAWN;


    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = SPAWN.position;
        //UnityEngine.Debug.Log("Started PController");
        //print(enemytarg);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        motor = GetComponent<PlayerMotor>();
        runawayObj = GetComponent<RunAwayController>();

    }

    // Update is called once per frame
    void Update()
    {


        float endist = Vector3.Distance(enemytarg.position, transform.position);

        if (transform.name == "Red Player")
        {
            UnityEngine.Debug.Log(transform.name);
            UnityEngine.Debug.Log(endist);

        }


        if (endist > 50)
        {

            motor.MoveToPoint(enemytarg.position);
        }

        else if (endist < 40)
        {
            runawayObj.AdjOffset((endist + .1F) + 1F);

            motor.MoveToPoint(runaway.position); 
        }

        //UnityEngine.Debug.Log(interactable);

        
        

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


    


}
