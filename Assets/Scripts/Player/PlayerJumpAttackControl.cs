using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAttackControl : MonoBehaviour
{
    private PlayerMoveControl pMC;
    public CircleCollider2D cirCol;

    private void Awake()
    {
        cirCol.enabled = false;
    }

    private void Start()
    {
        pMC = GetComponent<PlayerMoveControl>();
    }

    private void FixedUpdate()
    {
        JumpAttack();
    }

    private void JumpAttack()
    {
        if (pMC.grounded)
        {
            ResetJumpAttack();
        }
        else
        {
            ActivateJumpAttack();
        }
    }

    public void ActivateJumpAttack()
    {
        cirCol.enabled = true;
    }

    public void ResetJumpAttack()
    {
        cirCol.enabled = false;
    }
}
