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
                //pos =  // 추후 작성
                break;
            case RandomSpownPosType.InBoxRandom:
                //pos =  // 추후 작성
                break;
            case RandomSpownPosType.AllRandom:
                //pos =  // 추후 작성
                break;
            case RandomSpownPosType.WidthRandom:
                //pos =  // 추후 작성
                break;
            case RandomSpownPosType.HeightRandom:
                //pos =  // 추후 작성
                break;
            default:
                throw new System.Exception("Error : Not enum type");
        }

        return pos;
    }
}
public enum RandomSpownPosType
{
    OutBoxRandom, // 박스 바깥 아무데나
    InBoxRandom,  // 박스 안에 아무데나
    AllRandom,    // 진짜 아무데나
    WidthRandom,  // x축 렌덤 위치(y축은 상단 고정)
    HeightRandom, // y축 랜덤 위치(x축은 좌우 랜덤)
}
