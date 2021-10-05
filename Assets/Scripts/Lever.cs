using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Animator anim;
    public GameObject icon;

    private void Start()
    {
        anim = GetComponent<Animator>();
        GameManager.RegisterLever(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.RemoveLeverFromList(this);

            anim.SetTrigger("Unlock");

            icon.SetActive(false);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
