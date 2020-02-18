using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    public GameObject deathEffect;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Enemy")
        {

            Instantiate(deathEffect, transform.position, Quaternion.identity);

            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "DeadZone")
        {
            SceneManager.LoadScene(0);
        }
    }
}
