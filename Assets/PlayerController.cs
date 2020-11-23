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
    public Transform runaway2;


    PlayerMotor motor;
    RunAwayController runawayObj;
    Interactable focus;
    public Transform SPAWN;
    public float speed = 10f;

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

        if (transform.name == ("Red Player") || transform.name == ("Red Player 2"))
        {
            Interactable interactable = enemytarg.GetComponent<Interactable>();

            if (interactable != null)
            {
                UnityEngine.Debug.Log("hello");
                SetFocus(interactable);
            }
        }



        if (transform.name == "Blue Player")
        {

           Vector3 pos = transform.position;

           if (Input.GetKey ("w")) {
               pos.z += speed * Time.deltaTime;
           }
           if (Input.GetKey ("s")) {
               pos.z -= speed * Time.deltaTime;
           }
           if (Input.GetKey ("d")) {
               pos.x += speed * Time.deltaTime;
           }
           if (Input.GetKey ("a")) {
               pos.x -= speed * Time.deltaTime;
           }


           transform.position = pos;
            /*
            //distance from player to enemy1, enemy2
            float rundist = Vector3.Distance(runaway.position, transform.position);
            float rundist2 = Vector3.Distance(runaway2.position, transform.position);

            //distance from player to cube
            float endist = Vector3.Distance(enemytarg.position, transform.position);

            //Unit vector to cube
            Vector3 endir = Vector3.Normalize(transform.position - enemytarg.position);


            //adjust length of endir vector
            if (endist < 3)
            {
                Interactable interactable = enemytarg.GetComponent<Interactable>();

                SetFocus(interactable);
            }

            //multiplier
            if (endist < 20)
            {
                //UnityEngine.Debug.Log("20");
                endir *= 9;

            }

            else if (endist < 30)
            {
                //UnityEngine.Debug.Log("30");
                endir *= 6;
            }

            else if (endist < 40)
            {
                //UnityEngine.Debug.Log("40");
                endir *= 3;
            }


            //Runaway vectors
            Vector3 rundir = Vector3.Normalize(transform.position - runaway.position) * (10/rundist);
            Vector3 rundir2 = Vector3.Normalize(transform.position - runaway2.position) * (10 / rundist2);


            Vector3 findir = (rundir + rundir2 - endir) * 4;
            //UnityEngine.Debug.Log(findir);
            motor.MoveToPoint(transform.position + findir);

            //UnityEngine.Debug.Log(endir);
            */
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

    /*
    void OnCollisionEnter(Collision colliderInfo)
    {
        if (transform.name == "Blue Player")
        {
            if (colliderInfo.collider.name == "redFloor")
            {
                Globals.isCollRed = true;
                Globals.isCollBlue = false;
            }

            else if (colliderInfo.collider.name == "Floor")
            {
                Globals.isCollRed = false;
                Globals.isCollBlue = true;
            }
        }
    }
    */

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        motor.StopFollowingTarget();
    }


    /*
    Vector3 attack()
    {
        //distance from player to enemy1, enemy2
        float rundist = Vector3.Distance(runaway.position, transform.position);
        float rundist2 = Vector3.Distance(runaway2.position, transform.position);

        //distance from player to cube
        float endist = Vector3.Distance(enemytarg.position, transform.position);

        //Unit vector to cube
        Vector3 endir = Vector3.Normalize(transform.position - enemytarg.position);


        //adjust length of endir vector
        if (endist < 3)
        {
            Interactable interactable = enemytarg.GetComponent<Interactable>();

            SetFocus(interactable);
        }

        //multiplier
        if (endist < 20)
        {
            //UnityEngine.Debug.Log("20");
            endir *= 9;

        }

        else if (endist < 30)
        {
            //UnityEngine.Debug.Log("30");
            endir *= 6;
        }

        else if (endist < 40)
        {
            //UnityEngine.Debug.Log("40");
            endir *= 3;
        }


        //Runaway vectors
        Vector3 rundir = Vector3.Normalize(transform.position - runaway.position) * (10 / rundist);
        Vector3 rundir2 = Vector3.Normalize(transform.position - runaway2.position) * (10 / rundist2);


        Vector3 findir = (rundir + rundir2 - endir) * 4;

        return(findir)
    }
    */




}
