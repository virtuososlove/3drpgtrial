using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemyhealth : MonoBehaviour
{
    public float currenthealth;
    public float maxhealth = 100f;
    Animator anim;
    public Image healthbar;
    public Canvas canvas;
    void Start()
    {
        currenthealth = maxhealth;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        if(currenthealth <= 0)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("death"))
            {
                anim.SetBool("death", true);
                anim.ResetTrigger("hit");
                GetComponent<EnemyWaypointTracker>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
                canvas.gameObject.SetActive(false);
                enabled = false;
            }
        }
    }
    public void takedamage(float amount)
    {
        if(currenthealth > 0)
        {
            anim.SetTrigger("hit");
            currenthealth -= amount;
            healthbar.fillAmount = currenthealth / maxhealth;
        }
    }
    public void destroyobject()
    {
        anim.ResetTrigger("hit");
        Destroy(gameObject,1f);
    }
}
