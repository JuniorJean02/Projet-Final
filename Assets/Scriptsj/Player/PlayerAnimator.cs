using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    //Refrences
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.moveDir.x != 0 || pm.moveDir.y != 0)
        {
            am.SetBool("Move", true);
            SpriteDirectionChecheker();
        }

        else
        {
            am.SetBool("Move", false);
        }
    }

    void SpriteDirectionChecheker()
    {
        if (pm.Lasthorizonvector < 0)
        {
            sr.flipX = true;
        }

        else { sr.flipX = false; }
    }
}
