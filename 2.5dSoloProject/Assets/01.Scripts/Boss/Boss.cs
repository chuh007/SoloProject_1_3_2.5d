using System.Collections;
using UnityEngine;

public class Boss : Entity
{
    private float PatternCollTime = 1f;

    private void OnBattle()
    {

    }

    private IEnumerator PatternSellect()
    {
        yield return new WaitForSeconds(PatternCollTime);
    }
}
