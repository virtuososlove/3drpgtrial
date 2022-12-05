using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic_Attack : MonoBehaviour
{
    public float damage = 10f;
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.GetComponent<enemyhealth>() != null)
        other.gameObject.GetComponent<enemyhealth>().takedamage(damage);
    }
}
