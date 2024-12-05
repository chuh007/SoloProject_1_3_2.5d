using System.Collections;
using UnityEngine;

public class PatternLauncher : MonoBehaviour, IEntityComponent
{
    [SerializeField] private Transform attackTrm;

    private float cycleStartTime;
    private Entity onwer;

    private PatternData nowPattern;


    public void Initialize(Entity entity)
    {
        onwer = entity;
    }

    public void LaunchPattern()
    {
        StartCoroutine(PatternAttack());
    }

    public void GetNextPatternData(PatternData pattern)
    {
        nowPattern = pattern;
    }

    private Vector3 RandomPosSetter(RandomSpownPosType type)
    {
        Vector3 pos = new Vector3(0, 0, 0);

        switch (type)
        {
            case RandomSpownPosType.OutBoxRandom:
                //pos.x = 
                break;
            case RandomSpownPosType.InBoxRandom:
                pos.x = Random.Range(-10f, 10f);
                pos.y = Random.Range(-7f, 3f);
                break;
            case RandomSpownPosType.AllRandom:
                pos.x = Random.Range(-17f, 17f);
                pos.y = Random.Range(-9f, 9f);
                break;
            case RandomSpownPosType.TopRandom:
                pos.x = Random.Range(-17f, 17f);
                pos.y = 9f;
                break;
            case RandomSpownPosType.HeightRandom:
                pos.x = Random.Range(0, 2) == 1 ? -15f : 15f;
                pos.y = Random.Range(-9f, 9f);
                break;
            default:
                throw new System.Exception("Error : Not enum type");
        }

        return pos;
    }

    protected float DirectionSetter(SetDirectionType type)
    {
        float dir = 0f;

        switch (type)
        {
            case SetDirectionType.Random:
                dir = Random.Range(0, 360f);
                break;
            case SetDirectionType.SeeTarget:
                // TODO
                break;
            case SetDirectionType.Up:
                dir = 90;
                break;
            case SetDirectionType.Down:
                dir = -90;
                break;
            case SetDirectionType.Left:
                dir = 180;
                break;
            case SetDirectionType.Right:
                dir = 0;
                break;
            default:
                throw new System.Exception("Error : Not enum type");

        }

        return dir;
    }


    private IEnumerator PatternAttack()
    {
        cycleStartTime = Time.time;
        while (nowPattern.cycleTime + cycleStartTime > Time.time)
        {
            yield return new WaitForSeconds(nowPattern.attackDelay);
            PopPoolEvent evt = Events.popPoolEvent;
            evt.popName = "Laser";
            EventManager.RasiseEvent(evt);
            IPoolable poolable = evt.pop;
            Debug.Log(poolable);
            Attack attack = poolable as Attack;
            Debug.Log(attack);
            attack.Initialize(RandomPosSetter(nowPattern.spownType), DirectionSetter(nowPattern.dirType));
            attack.ReadyAttack();
        }
    }

    

}
public enum RandomSpownPosType
{
    OutBoxRandom, // 박스 바깥 아무데나
    InBoxRandom,  // 박스 안에 아무데나
    AllRandom,    // 진짜 아무데나
    TopRandom,  // x축 렌덤 위치(y축은 상단 고정)
    HeightRandom, // y축 랜덤 위치(x축은 좌우 랜덤)
}
