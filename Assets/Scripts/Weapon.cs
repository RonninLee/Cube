using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public MeshRenderer renderer;

    public PlayerDead playerDead;

    private void Start()
    {
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (playerDead.isDead) renderer.enabled = false;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        else timeBetweenShots += Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(projectile, shotPoint.position, shotPoint.rotation);
    }
}
