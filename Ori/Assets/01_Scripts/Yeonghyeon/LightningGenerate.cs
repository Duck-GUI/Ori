using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningGenerate : MonoBehaviour
{
    [SerializeField] private GameObject lightning;
    private float rotaionVal = 90;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(lightning, new Vector3(Random.Range(25,-25),0,Random.Range(25,-25)),transform.rotation);
        }
    }
}
