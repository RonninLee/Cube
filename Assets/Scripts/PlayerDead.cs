using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    public GameObject deathEffect;

    public float maxHealth;
    public float currentHealth;

    public float heal;

    public HUD hud;

    private Rigidbody2D rb;

    public MeshRenderer renderer;
    public bool isDead;

    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;

        heal = 25;

        isDead = false;

        hud = FindObjectOfType<HUD>();
        hud.UpdateHealthUI(currentHealth, maxHealth);

        rb = GetComponent<Rigidbody2D>();

        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        HarrasHealth();
    }

    void HarrasHealth()
    {
        if(currentHealth >= 0)
        {
            currentHealth -= Time.deltaTime * 20;
            hud.UpdateHealthUI(currentHealth, maxHealth);
        }
        else
        {
            Dead();
        }      
    }

    public void HealOnKill()
    {
        currentHealth += heal;
        hud.UpdateHealthUI(currentHealth, maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Enemy")
        {
            Dead();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "DeadZone")
        {
            Dead();
        }
    }

    void Dead()
    {
        Invoke("LoadScene", 0.5f);
        currentHealth = maxHealth;
        renderer.enabled = false;
        isDead = true;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
