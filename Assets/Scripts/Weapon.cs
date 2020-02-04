using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    private void Update()
    {
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
