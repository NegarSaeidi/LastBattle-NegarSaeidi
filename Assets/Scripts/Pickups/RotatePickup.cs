using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePickup : MonoBehaviour
{
 
    void Update()
    {
        this.gameObject.transform.Rotate(Vector3.up, 0.5f);
    }
}
