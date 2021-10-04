using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float health;
    public bool canTakeDamage = true;

    protected Rigidbody2D rb;
    protected Animator anim;

    public AudioClip hurtClip;
    public AudioClip deathClip;
    protected AudioSource audioSource;

    public GameObject[] itemDrops;
    public int[] rateDrops;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            health -= damage;
            anim.SetBool("Damage", true);
            audioSource.clip = hurtClip;
            audioSource.Play();

            if (health <= 0)
            {

                GetComponent<BoxCollider2D>().enabled = false;
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
            audioSource.clip = deathClip;
            audioSource.Play();
            anim.SetBool("Explode", true);
        }
    }

    public virtual void DropItem()
    {

    }


    public void Fade()
    {
        anim.SetBool("Fade", true);
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
