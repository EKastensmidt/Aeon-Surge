using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject target;
    private bool targetLocked = true;

    public float offset;
    public GameObject turretTopPart;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public float fireTimer;
    private bool shootReady = true;
    void Update()
    {
        if (targetLocked)
        {
            turretTopPart.transform.LookAt(target.transform);
            turretTopPart.transform.Rotate(offset, 0, 0);
            if (shootReady)
            {
                Shoot();
            }
        }
    }
    void Shoot()
    {
        //SoundManagerScript.PlaySound("Lazer");
        Transform _bullet = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        _bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        shootReady = false;
        StartCoroutine(FireRate());
    }
    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        shootReady = true;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Plataform")
    //    {
    //        target = other.gameObject;
    //        targetLocked = true;
    //    }
    //}
}
