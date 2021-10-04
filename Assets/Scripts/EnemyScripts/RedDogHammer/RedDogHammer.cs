using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDogHammer : Enemy
{
    public float speed;
    private int direction = -1;
    public float waitTime;
    public float attackCooldown;

    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask layerToCheck;

    public PolygonCollider2D polyCol;

    private bool detectGround;
    private bool detectWall;

    public float radius;

    private void FixedUpdate()
    {
        Move();
        Attack();
        SetAnimatorValues();
    }

    private void Move()
    {
        if (health > 0)
        {
            Flip();

            if (hasControl && !wait && !playerInArea)
            {
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            }
        }
    }

    private void Attack()
    {
        if(playerInArea)
        {
            if (!canAttack)
                return;

            canAttack = false;
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
            polyCol.enabled = false;
            canAttack = true;
            StopCoroutine(AttackCooldown());
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
        polyCol.enabled = false;
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

private void Flip()
    {
        detectGround = Physics2D.OverlapCircle(groundCheck.position, radius, layerToCheck);
        detectWall = Physics2D.OverlapCircle(wallCheck.position, radius, layerToCheck);

        if (detectWall || !detectGround)
        {
            if (!wait)
            {
                StartCoroutine(WaitEnemy());
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        Gizmos.DrawWireSphere(wallCheck.position, radius);
    }

    private IEnumerator WaitEnemy()
    {
        wait = true;

        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(waitTime);
        direction *= -1;
        transform.localScale = new Vector3(-transform.localScale.x, 1, 1);

        wait = false;
    }
}
