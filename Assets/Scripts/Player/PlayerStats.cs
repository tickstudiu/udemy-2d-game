using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Cinemachine;


public class PlayerStats : MonoBehaviour
{
    private Animator anim;
    private PlayerMoveControl pMC;
    private CinemachineImpulseSource impulseSource;

    public float maxHealth;
    public float health;
    private Text textComponent;

    public bool canTakeDamage = true;
    public AudioClip hurtClip;
    private AudioSource audioSource;

    void Start()
    {
        textComponent = GameObject.FindGameObjectWithTag("HeartUI").GetComponentInChildren<Text>();
        pMC = GetComponentInParent<PlayerMoveControl>();
        anim = GetComponentInParent<Animator>();
        audioSource = GetComponentInParent<AudioSource>();
        impulseSource = GetComponent<CinemachineImpulseSource>();

        health = maxHealth;
        UpdateText();
    }

    public void TakeDamage(float damage)
    {
        if(canTakeDamage)
        {
            health -= damage;
            UpdateText();

            anim.SetBool("Damage", true);

            pMC.hasControl = false;
            pMC.ExitLadders();

            audioSource.clip = hurtClip;
            audioSource.Play();

            impulseSource.GenerateImpulse();

            if (health <= 0)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponentInParent<GatherInput>().DisableControls();

                GameManager.ManagerOpenDeathMenu();
            }

            StartCoroutine(DamagePrevention());
        }
    }

    private void UpdateText()
    {
        textComponent.text = health.ToString();
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if(health > 0)
        {
            anim.SetBool("Damage", false);
            canTakeDamage = true;
            pMC.hasControl = true;
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }

    public void IncreaseHealth(float heal)
    {
        health += heal;

        if (health > maxHealth) health = maxHealth;

        UpdateText();
    }
}
