using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeronclick : MonoBehaviour
{
    float playerpointTodistance;
    public float attackrange =2f;
    bool canmove;
    bool canattakmove;

    float height;
    float gravity = 9.8f;
    public Vector3 targetmovepoint;
    Animator anim;
    Vector3 newmovepoint;
    Vector3 newattackpoint;
    Vector3 playermove = Vector3.zero;
    Vector3 targetattackpoint;
    GameObject enemy;

    public float currentspeed = 5f;
    private CollisionFlags collisionflags;
    public bool finishedmovement = true;
    void Start()
    {
        anim = transform.GetChild(0).transform.gameObject.GetComponent<Animator>();
    }
    void Update()
    {

        calculateheight();
        checkifFinishedMovement();
        canmovetest();
        attackmove();
    }
    bool isgrounded()
    {
        return collisionflags == CollisionFlags.CollidedBelow ? true : false;
    }
    void calculateheight()
    {
        if (isgrounded())
        {
            height = 0;
        }
        else
        {
            height -= Time.deltaTime * gravity;
        }
    }
    void checkifFinishedMovement()
    {
        if (!finishedmovement)
        {
            if (!anim.IsInTransition(0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                finishedmovement = true;
            }
        }
        else
        {
            moveplayer();
            playermove.y += height * Time.deltaTime;
            collisionflags = GetComponent<CharacterController>().Move(playermove);
        }
    }
    void attackmove()
    {
        if (canattakmove)
        {
            targetattackpoint = enemy.transform.position;
            newattackpoint = new Vector3(targetattackpoint.x, transform.position.y, targetattackpoint.z);
        }
        if(!anim.IsInTransition(0)&& anim.GetCurrentAnimatorStateInfo(0).IsName("basic attack"))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newattackpoint - transform.position), Time.deltaTime * 35);
        }
    }
    void canmovetest()
    {
        if (Input.GetMouseButton(1))
        {

            Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseray, out hit))
            {
                playerpointTodistance = Vector3.Distance(transform.position, hit.point);
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    canattakmove = false;
                    anim.SetBool("attack", false);
                    if (playerpointTodistance >= 1f)
                    {

                        canmove = true;
                        canattakmove = false;
                        targetmovepoint = hit.point;
                    }

                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("target"))
                {
                    canattakmove = true;
                    canmove = true;
                    enemy = hit.collider.gameObject.GetComponentInParent<EnemyWaypointTracker>().gameObject;
                }
            }
        }
    }
    void moveplayer()
    {
        if (canmove == true)
        {
            anim.SetFloat("speed", 1f);
            if (!canattakmove)
            {
                newmovepoint = new Vector3(targetmovepoint.x, transform.position.y, targetmovepoint.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newmovepoint - transform.position), 15 * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newattackpoint - transform.position), 15 * Time.deltaTime);
            }
            playermove = transform.forward * currentspeed * Time.deltaTime;
            if (Vector3.Distance(newmovepoint, transform.position) <= 0.6f && !canattakmove)
            {
                canmove = false;
            }
            else if (canattakmove)
            {
                if (Vector3.Distance(transform.position, newattackpoint) <= attackrange)
                {
                    playermove = Vector3.zero;
                    anim.SetFloat("speed", 0);
                    anim.SetBool("attack", true);
                }
            }
        }
        else
        {
            playermove = Vector3.zero;
            anim.SetFloat("speed", 0);
        }
         
    }
    
}
