using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected LayerMask _targetLayer;

    protected bool _isDead = false; 
    protected float _timer = 0f;

    protected Rigidbody2D _rigidBody;

    protected void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void ResetItem()
    {
        _isDead = false;
        _timer = 0f;
    }

    public abstract void InitAndFire(Transform firePosTrm, int damage);
}
