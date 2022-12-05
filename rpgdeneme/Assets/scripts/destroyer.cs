using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    public float destroytime;
    void Start()
    {
        Destroy(gameObject, destroytime);
    }

}
