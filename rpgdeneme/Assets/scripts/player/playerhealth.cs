using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    public float maxhealth;
    public float currenthealth;
    float regenspeed = 2f;
    Animator playeranimator;
    public Image healthorb;
    public bool isshielded;
    private void Start()
    {
        currenthealth = maxhealth;
        playeranimator = gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Animator>();
        
    }
    private void Update()
    {
        if(currenthealth<= maxhealth)
        {
            currenthealth += Time.deltaTime * regenspeed;
        }
        if(currenthealth <= 0)
        {
            playeranimator.SetTrigger("death");
            GetComponent<CharacterController>().enabled = false;
            GetComponent<CharacterController>().center = new Vector3(0, -15, 0.1f);
            GetComponent<CharacterController>().height = 0f;
            GetComponent<playeronclick>().enabled = false;
            enabled = false;
        }
    }
    public void takedamage(float damageamount)
    {
        if(isshielded != true)
        {
            if (currenthealth >= 0)
            {
                currenthealth -= damageamount;
                updatehealthorb();

            }
        }
    }
    public void healplayer(float amount)
    {
        if(currenthealth < maxhealth)
        {
            currenthealth += amount;
            updatehealthorb();
        }
    }
    void updatehealthorb()
    {
        healthorb.fillAmount = currenthealth / maxhealth;
    }
}
