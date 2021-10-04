using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladders : MonoBehaviour
{
    private GatherInput gI;
    private PlayerMoveControl pMC;
    private Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gI = collision.GetComponent<GatherInput>();
        pMC = collision.GetComponent<PlayerMoveControl>();
        anim = collision.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(gI.tryToClimb)
        {
            pMC.onLadders = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pMC.ExitLadders();
    }
}
