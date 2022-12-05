using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControl : MonoBehaviour
{
    GameObject player;
    public float radius;
    public LayerMask enemylayer;
    enemyhealth enemyhealth;
    public float damagecount = 10f;
    protected bool colided;
    void Start()
    {
        player = GameObject.Find("player").transform.GetChild(0).transform.gameObject;
    }
    internal virtual void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemylayer);
        foreach (Collider hit in hits)
        {
            enemyhealth = hit.GetComponent<enemyhealth>();
            colided = true;
        }
        if (colided == true)
        {
            if(enemyhealth.currenthealth > 0)
            {
                enemyhealth.takedamage(damagecount);
            }
            enabled = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
