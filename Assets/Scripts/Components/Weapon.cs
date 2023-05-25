using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public float timeDelay;
    
    [SerializeField] private int damageBullet;
    public void Shoot()
    {
         Vector3 frwd = Vector3.MoveTowards(transform.position, 
             InputController.Instance.cursorPosition, 100);
         frwd.y = transform.position.y;
         float time = Vector3.Distance(transform.position, frwd) / 10f;
         BulletPoolsController.Instance.CreateBullet(frwd, damageBullet, time, transform.position);
    }
}
