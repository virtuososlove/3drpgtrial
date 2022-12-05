using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiled : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("player");
        player.GetComponent<playerhealth>().isshielded = true;

    }
    private void OnDisable()
    {
        player.GetComponent<playerhealth>().isshielded = false;

    }
}
