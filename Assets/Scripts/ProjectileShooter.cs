using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    GameObject prefab;
    public float speed = 40;
    public float seconds = 2;
    public Transform projectileSpawn;

    void Start()
    {
        prefab = Resources.Load("SimpleLightningBoltAnimatedPrefab") as GameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(prefab, projectileSpawn.position,Camera.main.transform.rotation) as GameObject;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * speed;
            Destroy(projectile, seconds);
            SoundManagerScript.PlaySound("Electricity");
        }
    }
}
