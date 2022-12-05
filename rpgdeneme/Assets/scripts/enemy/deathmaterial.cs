using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathmaterial : MonoBehaviour
{
    public Material dissolve;
    void Start()
    {
        GetComponent<Renderer>().material = dissolve;
        GetComponent<SpawnEffect>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
