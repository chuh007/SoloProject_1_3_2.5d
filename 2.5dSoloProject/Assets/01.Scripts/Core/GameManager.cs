using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private Dictionary<string, Pool> _pools;

    [SerializeField] private BulletDice _bullet;
    private void Awake()
    {
        _pools = new Dictionary<string, Pool>();
        Pool bulletPool = new Pool(_bullet, transform, 15);
        _pools.Add(_bullet.PoolName, bulletPool);
    }

    public IPoolable Pop(string poolName)
    {
        IPoolable item = _pools[poolName].Pop();
        item.ResetItem();
        return item;
    }

    public void Push(IPoolable item)
    {
        _pools[item.PoolName].Push(item);
    }
}
