using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    private Vector3 randomPos;
    private float spawnTime;

    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime > 3)
        {
            Spawn();
            spawnTime = 0;
        }
    }

    private void Spawn()
    {
        randomPos = new Vector3(Random.Range(-20, 20), 10, Random.Range(-20, 20));
        int ran = Random.Range(0, items.Length);
        Debug.Log(ran);
        Instantiate(items[ran], randomPos, Quaternion.identity);
    }
}