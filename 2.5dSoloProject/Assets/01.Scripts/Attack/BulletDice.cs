using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BulletDice : Projectile, IPoolable
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _lifeTime = 2f;

    private int _damage;
    private Vector2 _fireDirection;

    [SerializeField] private string _poolName;
    public string PoolName => "BulletDice";
    public GameObject ObjectPrefab => gameObject;

    public override void InitAndFire(Transform firePosTrm, int damage)
    {
        _damage = damage;
        transform.SetPositionAndRotation(firePosTrm.position, firePosTrm.rotation);
        _fireDirection = firePosTrm.right;
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocity = _fireDirection * _moveSpeed;
        _timer = Time.fixedDeltaTime;

        if (_timer >= _lifeTime)
        {
            DestoryBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead) return;

        DestoryBullet();
    }

    private void DestoryBullet()
    {
        _isDead = true;
        GameManager.Instance.Push(this);
    }

}
