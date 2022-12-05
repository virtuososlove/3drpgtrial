using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerskilleffect : MonoBehaviour
{
    public GameObject[] skilleffects;
    public Transform[] skilleffecttransforms;
    public void hammerskilleffect()
    {
        Instantiate(skilleffects[0], skilleffecttransforms[0].position, Quaternion.identity);
    }
    public void kickskilleffect()
    {
        Instantiate(skilleffects[1], skilleffecttransforms[1].position, Quaternion.identity);
    }
    public void spellskilleffect()
    {
        Instantiate(skilleffects[2], skilleffecttransforms[2].position, Quaternion.identity);
    }
    public void shiledskilleffect()
    {
        GameObject shiled = Instantiate(skilleffects[3], transform.position, Quaternion.identity);
        shiled.transform.parent = transform;
    }
    public void healskilleffect()
    {
        GameObject heal = Instantiate(skilleffects[4], transform.position, Quaternion.identity);
        heal.transform.parent = transform;
    }
    public void comboskilleffect()
    {
        Instantiate(skilleffects[5], skilleffecttransforms[3].position, Quaternion.identity);
    }
}
