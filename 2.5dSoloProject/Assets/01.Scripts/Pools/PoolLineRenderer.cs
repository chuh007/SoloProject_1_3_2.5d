using UnityEngine;

public class PoolLineRenderer : MonoBehaviour, IPoolable
{
    public string PoolName => "LineRenderer";

    private LineRenderer _line;

    public GameObject ObjectPrefab => gameObject;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    public void ResetItem()
    {
        _line.positionCount = 0;
        
    }

    public void InitAndDrawLine(Vector3 startPos, Vector3 endPos)
    {
        _line.positionCount = 2;
        _line.SetPosition(0, startPos);
        _line.SetPosition(1, endPos);
    }
}
