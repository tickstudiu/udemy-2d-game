using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public bool canTakeDamage = true;
    public bool canAttack = true;
    public bool playerInArea = false;
    public bool wait = false;
    public bool hasControl = true;
    public bool ago = false;

    protected Rigidbody2D rb;
    protected Animator anim;

    public AudioClip hurtClip;
    public AudioClip deathClip;
    public AudioClip attackClip;
    protected AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetAnimatorValues();
    }

    public void TakeDamage(float damage)
    {
        ago = true;

        if (canTakeDamage)
        {
            health -= damage;

            anim.SetBool("Damage", true);

            audioSource.clip = hurtClip;
            audioSource.Play();

            if (health <= 0)
            {
                hasControl = false;

                GetComponent<CapsuleCollider2D>().enabled = false;
                PolygonCollider2D[] polyCols = GetComponentsInChildren<PolygonCollider2D>();
                foreach (PolygonCollider2D polyCol in polyCols)
                    polyCol.enabled = false;

                rb.gravityScale = 0;
            }

            StartCoroutine(DamagePrevention());
        }
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if (health > 0)
        {
            anim.SetBool("Damage", false);
            canTakeDamage = true;
        }
        else
        {
            rb.velocity = Vector2.zero;
            audioSource.clip = deathClip;
            audioSource.Play();
            anim.SetBool("Death", true);
        }
    }

    public void Fade()
    {
        anim.SetBool("Fade", true);
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    protected void SetAnimatorValues()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Ago", ago);
        anim.SetBool("Wait", wait);
        anim.SetBool("HasControl", hasControl);
        anim.SetBool("PlayerInArea", playerInArea);
    }
}
