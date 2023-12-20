using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDestroy : MonoBehaviour
{
    [SerializeField] private float time;
    private void Start()
    {
        StartCoroutine(DestoyTime());
    }

    private IEnumerator DestoyTime()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
