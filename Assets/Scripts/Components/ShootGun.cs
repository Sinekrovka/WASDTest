using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : Weapon
{
    private bool shoot;
    private void Start()
    {
        shoot = false;
        InventoryController.Instance.AddWeapon(this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !shoot)
        {
            shoot = true;
            StartCoroutine(ShootGunShoot());
        }

        if (Input.GetMouseButtonUp(0) && shoot)
        {
            shoot = false;
            StopAllCoroutines();
        }
    }


    private IEnumerator ShootGunShoot()
    {
        Shoot();
        yield return new WaitForSeconds(timeDelay);
        StartCoroutine(ShootGunShoot());
    }
}
