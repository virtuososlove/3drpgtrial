using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sworddamage : MonoBehaviour
{
    public float damage = 4f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<playerhealth>() != null)
        {
            other.GetComponent<playerhealth>().takedamage(damage);
        }
    }
}
