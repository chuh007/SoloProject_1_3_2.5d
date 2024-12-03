using UnityEngine;

public class PatternLauncher : MonoBehaviour
{
    [SerializeField] private Attack patternPrefab;
    private Transform AttackTrm;

    private Vector3 RandomPosSetter(RandomSpownPosType type)
    {
        Vector3 pos = new Vector3(0, 0, 0);

        switch (type)
        {
            case RandomSpownPosType.OutBoxRandom:
                //pos =  // ���� �ۼ�
                break;
            case RandomSpownPosType.InBoxRandom:
                //pos =  // ���� �ۼ�
                break;
            case RandomSpownPosType.AllRandom:
                pos.x = Random.Range(-17f, 17f);
                pos.y = Random.Range(-9f, 9f);
                AttackTrm.position = pos;
                break;
            case RandomSpownPosType.TopRandom:
                //pos =  // ���� �ۼ�
                break;
            case RandomSpownPosType.HeightRandom:
                //pos =  // ���� �ۼ�
                break;
            default:
                throw new System.Exception("Error : Not enum type");
        }

        return pos;
    }

    public void LaunchPattern()
    {
        patternPrefab.Initialize(AttackTrm.position, AttackTrm.rotation.z);
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
