using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage;

    public void SetDamage(int newDamage)
    {
        _damage = newDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IEnemy enemy))
        {
            enemy.Damage(_damage);
            transform.DOKill();
            BulletPoolsController.Instance.DestroyBullet(this);
        }
    }
}
