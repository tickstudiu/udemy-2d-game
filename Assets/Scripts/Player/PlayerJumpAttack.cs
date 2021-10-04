using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAttack : MonoBehaviour
{
    public float jumpAttackDamage;
    private int enemyLayer;

    private PlayerMoveControl pMC;
    private Rigidbody2D rb;
    private GatherInput gI;
    private AudioSource audioSource;


    void Start()
    {
        pMC = GetComponentInParent<PlayerMoveControl>();
        rb = GetComponentInParent<Rigidbody2D>();
        gI = GetComponentInParent<GatherInput>();
        audioSource = GetComponentInParent<AudioSource>();

        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            collision.GetComponent<Enemy>().TakeDamage(jumpAttackDamage);

            rb.velocity = new Vector2(pMC.speed * gI.valueX, pMC.jumpForce);

            audioSource.clip = pMC.jumpClip;
            audioSource.Play();
        }
    }
}
