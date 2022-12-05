using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    public float healamount;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("player");
        player.GetComponent<playerhealth>().healplayer(healamount);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
