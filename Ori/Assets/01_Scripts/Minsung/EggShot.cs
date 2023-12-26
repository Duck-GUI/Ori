using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggShot : MonoBehaviour
{
    [SerializeField] GameObject egg;
    [SerializeField] Transform firePos;

    
    // Update is called once per frame
    void Update()
    {
        EggFire();
    }

    void EggFire()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(egg,firePos.transform.position, firePos.transform.rotation);
        }
    }
}
