using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControl : MonoBehaviour
{

    private PlayerMoveControl pMC;
    private GatherInput gI;
    private Animator anim;

    public bool attackStarted = false;
    public PolygonCollider2D polyCol;

    public AudioClip attackClip;
    private AudioSource audioSource;

    void Start()
    {
        pMC = GetComponent<PlayerMoveControl>();
        gI = GetComponent<GatherInput>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Attack();
    }

    private void Attack()
    {
        if(gI.tryAttack)
        {
            if (attackStarted || !pMC.hasControl || pMC.knockBack) return;

            anim.SetBool("Attack", true);
            attackStarted = true;
        }
    }

    public void ActivateAttack()
    {
        polyCol.enabled = true;
        audioSource.clip = attackClip;
        audioSource.Play();
    }

    public void ResetAttack()
    {
        anim.SetBool("Attack", false);
        gI.tryAttack = false;
        attackStarted = false;
        polyCol.enabled = false;
    }
}
