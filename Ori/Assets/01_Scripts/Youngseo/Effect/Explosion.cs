using System.Collections;
using UnityEngine;

public class Explosion : PoolableMono
{
    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(1f);
    }

    public override void Init()
    {
        StartCoroutine(LifeTime());
    }
}