using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellskill : SkillControl
{
    float speed = 10f;
    public GameObject explosion;
    void Start()
    {
        GameObject player = GameObject.Find("player").transform.GetChild(0).transform.gameObject;
        transform.rotation = Quaternion.LookRotation(player.transform.forward);
    }

    // Update is called once per frame
    internal override void Update()
    {
        base.Update();
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (colided)
        {

            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            enabled = false;
        }
    }
}
