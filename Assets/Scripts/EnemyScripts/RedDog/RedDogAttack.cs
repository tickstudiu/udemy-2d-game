using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDogAttack : EnemyAttack
{
    PlayerMoveControl playerMove;

    public float forceX;
    public float forceY;
    public float duration;

    public override void SpecialAttack()
    {
        base.SpecialAttack();

        playerMove = playerStats.GetComponentInParent<PlayerMoveControl>();
        StartCoroutine(playerMove.KnockBack(forceX, forceY, duration, transform.parent));
    }
}
