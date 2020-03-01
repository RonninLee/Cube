using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float speed;

    public GameObject deathEffect;
    private PlayerDead playerHeal;

    private GameManager gm;

    public int score = 100;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Start()
    {
        playerHeal = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDead>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        moveDirection = (playerHeal.transform.position - transform.position).normalized * speed;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

        Destroy(gameObject, 6f);
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0) gm.AddScore(score);

        if(health <= 0)
        {
            Die();           
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
        playerHeal.HealOnKill();
    }
}
