using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollrawimage : MonoBehaviour
{
    public float verticalspeed;
    public float horizontalspeed;
    RawImage myrawimage;
 
    void Start()
    {
        myrawimage = GetComponent<RawImage>();
    }

    void Update()
    {
        Rect currentrect = myrawimage.uvRect;
        currentrect.x  -= Time.deltaTime * horizontalspeed;
        currentrect.y -= Time.deltaTime * verticalspeed;
        if(currentrect.x <=-1 || currentrect.x >= 1)
        {
            currentrect.x = 0;
        }
        if (currentrect.y <= -1 || currentrect.y >= 1)
        {
            currentrect.y = 0;
        }
        myrawimage.uvRect = currentrect;
    }
}
