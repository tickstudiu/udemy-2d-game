using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage;
    private int enemyLayer;
    private int objectLayer;

    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        objectLayer = LayerMask.NameToLayer("Object");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            collision.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        if (collision.gameObject.layer == objectLayer)
        {
            collision.GetComponent<Object>().TakeDamage(attackDamage);
        }
    }
}
