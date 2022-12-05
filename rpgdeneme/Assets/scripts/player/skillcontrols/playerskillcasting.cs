using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerskillcasting : MonoBehaviour
{
    public Image[] cooldownicons;
    public Image[] outofmanaicons;
    public float[] CooldownTimes;
    bool faded;
    private int[] fadeimages = new int[] { 0, 0, 0, 0, 0, 0 };
    private Animator anim;
    private bool canattack = true;
    private playeronclick playeronclick;
    private float currentmana;
    public float[] manaAmounts;
    public float manaregen = 2f;
    public float maxmana = 100;
    Image manabarimage;
    private void Awake()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        playeronclick = GetComponent<playeronclick>();
        currentmana = maxmana;
        manabarimage = GameObject.Find("manaorb").GetComponent<Image>();
    }
    void Update()
    {
        if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            canattack = true;
        }
        else
        {
            canattack = false;
        }
        if (currentmana < maxmana)
        {
            currentmana += Time.deltaTime * manaregen;
            manabarimage.fillAmount = currentmana / maxmana;
        }
        checkinput();
        checktofade();
        checkmanaicons();
    }
    void checkinput()
    {
        if (anim.GetInteger("Attack") == 0)
        {
            playeronclick.finishedmovement = false;
            if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                playeronclick.finishedmovement = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentmana >= manaAmounts[0])
        {
            playeronclick.targetmovepoint = transform.position;
            if (fadeimages[0] != 1 && canattack)
            {
                fadeimages[0] = 1;
                anim.SetInteger("Attack", 1);
                currentmana -= manaAmounts[0];
                turnplayer();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && currentmana >= manaAmounts[1])
        {
            playeronclick.targetmovepoint = transform.position;
            if (fadeimages[1] != 1 && canattack)
            {
                fadeimages[1] = 1;
                anim.SetInteger("Attack", 2);
                currentmana -= manaAmounts[1];
                turnplayer();

            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && currentmana >= manaAmounts[2])
        {
            playeronclick.targetmovepoint = transform.position;
            if (fadeimages[2] != 1 && canattack)
            {
                fadeimages[2] = 1;
                anim.SetInteger("Attack", 3);
                currentmana -= manaAmounts[2];
                turnplayer();

            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && currentmana >= manaAmounts[3])
        {
            playeronclick.targetmovepoint = transform.position;
            if (fadeimages[3] != 1 && canattack)
            {
                fadeimages[3] = 1;
                anim.SetInteger("Attack", 4);
                currentmana -= manaAmounts[3];
                turnplayer();

            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && currentmana >= manaAmounts[4])
        {
            playeronclick.targetmovepoint = transform.position;
            if (fadeimages[4] != 1 && canattack)
            {
                fadeimages[4] = 1;
                anim.SetInteger("Attack", 5);
                currentmana -= manaAmounts[4];
                turnplayer();

            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && currentmana >= manaAmounts[5])
        {
            playeronclick.targetmovepoint = transform.position;
            if (fadeimages[5] != 1 && canattack)
            {
                fadeimages[5] = 1;
                anim.SetInteger("Attack", 6);
                currentmana -= manaAmounts[5];
                turnplayer();

            }
        }
        else
        {
            anim.SetInteger("Attack", 0);
        }
    }
    void checktofade()
    {
        for (int i = 0; i < cooldownicons.Length; i++)
        {
            if (fadeimages[i] == 1)
            {
                if (fadeandwait(cooldownicons[i], CooldownTimes[i]))
                {

                    fadeimages[i] = 0;
                }
            }
        }

    }
    bool fadeandwait(Image fadeimage, float cooldowntime)
    {
        faded = false;
        if (fadeimage == null)
        {
            return faded;
        }
        if (!fadeimage.gameObject.activeInHierarchy)
        {
            fadeimage.gameObject.SetActive(true);
            fadeimage.fillAmount = 1;
        }
        fadeimage.fillAmount -= Time.deltaTime / cooldowntime;
        if (fadeimage.fillAmount <= 0)
        {
            fadeimage.gameObject.SetActive(false);
            faded = true;
        }
        return faded;
    }
    void checkmanaicons()
    {

        for (int i = 0; i < outofmanaicons.Length; i++)
        {
            if (currentmana < manaAmounts[i])
            {
                outofmanaicons[i].gameObject.SetActive(true);
            }
            else
            {
                outofmanaicons[i].gameObject.SetActive(false);
            }
        }
    }
    void turnplayer()
    {
        Vector3 targetpos = Vector3.zero;
        Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseray, out hit))
        {
            targetpos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetpos - transform.position), Time.deltaTime * 15000000);
    }
}
