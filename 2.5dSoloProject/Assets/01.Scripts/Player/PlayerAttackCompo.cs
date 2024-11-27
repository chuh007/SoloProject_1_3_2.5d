using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackCompo : MonoBehaviour, IEntityComponent
{
    [SerializeField] private float _atkCooldown;
    [SerializeField] private int _damage;
    [SerializeField] private BulletDice _dicePrefab;
    [SerializeField] private Transform ShootPoint;

    private Player _player;
    private float _lastAtkTime;
    public void Initialize(Entity entity)
    {
        _player = entity as Player;
    }

    public bool AttemptAttack()
    {
        if (_lastAtkTime + _atkCooldown > Time.time) return false;

        _lastAtkTime = Time.time;
        Attack();
        return true;
    }

    private void Attack()
    {
        Debug.Log("공격이다임마");
        Projectile newBullet = GameManager.Instance.Pop("BulletDice") as Projectile;
        newBullet.InitAndFire(ShootPoint, _damage);
    }
    private void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 point = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 dir = point - transform.position;
        float angle = MathF.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0,0,angle);
    }
}
