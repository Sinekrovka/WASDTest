using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public float timeDelay;
    
    [SerializeField] private int damageBullet;
    public void Shoot()
    {
         BulletPoolsController.Instance.CreateBullet(damageBullet, transform);
    }
}
