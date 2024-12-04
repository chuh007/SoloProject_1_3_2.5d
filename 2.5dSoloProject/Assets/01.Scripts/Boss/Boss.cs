using System.Collections;
using UnityEngine;

public class Boss : Entity
{
    private float PatternCollTime = 1f;

    private PatternSelector _selector;
    private PatternLauncher _launcher;

    private void Start()
    {
        _selector = GetCompo<PatternSelector>();
        _launcher = GetCompo<PatternLauncher>();
        StartCoroutine(PatternSellect());
    }

    private void OnBattle()
    {

    }

    private IEnumerator PatternSellect()
    {
        while (true)
        {
            yield return new WaitForSeconds(PatternCollTime);
            _selector.PatternRandomSellect();
        }
    }
}
