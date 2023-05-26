using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private int _health;

    private int _reserveHealth;
    private Transform _player;
    private NavMeshAgent _agent;
    public bool attack;

    void Start()
    {
        attack = true;
        _reserveHealth = _health;
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            _agent.destination = _player.position;
        }
        else
        {
            _agent.ResetPath();
        }
    }

    public void Damage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            KillYourself();
        }
    }

    private void KillYourself()
    {
        _health = _reserveHealth;
        EnemiesController.Instance.KillEnemy(this);
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }
}
