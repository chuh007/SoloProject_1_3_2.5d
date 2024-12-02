using UnityEngine;

public class PatternLauncher : MonoBehaviour
{
    [SerializeField] private Pattern patternPrefab;
    private Transform AttackTrm;

    public void LaunchPattern()
    {
        patternPrefab.Initialize(AttackTrm.position, AttackTrm.rotation.z);
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
                //pos =  // ���� �ۼ�
                break;
            case RandomSpownPosType.AllRandom:
                //pos =  // ���� �ۼ�
                break;
            case RandomSpownPosType.WidthRandom:
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
}
public enum RandomSpownPosType
{
    OutBoxRandom, // �ڽ� �ٱ� �ƹ�����
    InBoxRandom,  // �ڽ� �ȿ� �ƹ�����
    AllRandom,    // ��¥ �ƹ�����
    WidthRandom,  // x�� ���� ��ġ(y���� ��� ����)
    HeightRandom, // y�� ���� ��ġ(x���� �¿� ����)
}
