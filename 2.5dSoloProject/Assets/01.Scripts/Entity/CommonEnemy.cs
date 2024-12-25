using UnityEngine;

public class CommonEnemy : Entity
{
    [SerializeField] protected LayerMask _whatIsPlayer, _whatIsObstacle;

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}