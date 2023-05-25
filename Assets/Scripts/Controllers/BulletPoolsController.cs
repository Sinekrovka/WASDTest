using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPoolsController : MonoBehaviour
{
    public static BulletPoolsController Instance;
    
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _poolSize;

    private List<Bullet> _bullets;

    private void Awake()
    {
        Instance = this;
        _bullets = new List<Bullet>();
        GameObject bullets = new GameObject("Bullets");

        for (int i = 0; i < _poolSize; ++i)
        {
            var bul = Instantiate(_bulletPrefab, Vector3.zero, Quaternion.identity, bullets.transform);
            bul.gameObject.SetActive(false);
            _bullets.Add(bul);
        }
    }

    public void CreateBullet(Vector3 newPosBullet, int damage, float time, Vector3 playerPosition)
    {
        if (_bullets.Count > 0)
        {
            Bullet bull = _bullets[0];
            bull.SetDamage(damage);
            bull.transform.position = playerPosition;
            _bullets.RemoveAt(0);
            bull.gameObject.SetActive(true);
            bull.transform.DOMove(newPosBullet, time).SetEase(Ease.Linear).OnComplete(delegate { DestroyBullet(bull); });
        }
    }

    public void DestroyBullet(Bullet bull)
    {
        bull.gameObject.SetActive(false);
        bull.transform.position = Vector3.zero;
        _bullets.Add(bull);
    }
}
