using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{

    public Transform respawnPoint;
    public Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") Respawn();
    }

    void Respawn()
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
