using System.Collections;
using UnityEngine;

public class Explosion : PoolableMono
{
    private IEnumerator LifeTime()
    {
        Destroy(gameObject, 1f);
        yield return new WaitForSeconds(1f);
    }

    public override void Init()
    {
        StartCoroutine(LifeTime());
    }
}