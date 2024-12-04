using System.Collections;
using UnityEngine;

public class PatternLauncher : MonoBehaviour, IEntityComponent
{
    [SerializeField] private Transform AttackTrm;

    private float cycleStartTime;
    private Entity onwer;


    private PatternData nowPattern;


    public void Initialize(Entity entity)
    {
        onwer = entity;
    }

    private Vector3 RandomPosSetter(RandomSpownPosType type)
    {
        Vector3 pos = new Vector3(0, 0, 0);

        switch (type)
        {
            case RandomSpownPosType.OutBoxRandom:
                //pos =  // ���� �ۼ�
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
                pos.x = Random.Range(0, 1) == 1 ? -9f : 9f;
                pos.y = Random.Range(-9f, 9f);
                break;
            default:
                throw new System.Exception("Error : Not enum type");
        }

        return pos;
    }

    public void LaunchPattern()
    {
        StartCoroutine(PatternAttack());
    }


    private IEnumerator PatternAttack()
    {
        cycleStartTime = Time.time;
        while (nowPattern.cycleTime + cycleStartTime > Time.time)
        {
            yield return new WaitForSeconds(nowPattern.attackDelay);
            Debug.Log("Spown");
            Attack attack = Instantiate(nowPattern.AttackPrefab,transform).GetComponent<Attack>(); // TODO Ǯ�޴����� ��ȯ
            attack.Initialize(RandomPosSetter(nowPattern.spownType),90f);
            attack.ReadyAttack();
        }
    }

    public void NextPattern(PatternData pattern)
    {
        nowPattern = pattern;
    }

}
public enum RandomSpownPosType
{
    OutBoxRandom, // �ڽ� �ٱ� �ƹ�����
    InBoxRandom,  // �ڽ� �ȿ� �ƹ�����
    AllRandom,    // ��¥ �ƹ�����
    TopRandom,  // x�� ���� ��ġ(y���� ��� ����)
    HeightRandom, // y�� ���� ��ġ(x���� �¿� ����)
}
