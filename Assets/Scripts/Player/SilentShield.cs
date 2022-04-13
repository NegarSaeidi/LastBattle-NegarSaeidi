using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilentShield : MonoBehaviour
{
    public GameObject shield;
  

    // Update is called once per frame
    void Update()
    {
        if (MovementController.ShieldInUse && !shield.gameObject.activeInHierarchy)
            shield.SetActive(true);
        if (!MovementController.ShieldInUse && shield.gameObject.activeInHierarchy)
            shield.SetActive(false);
    }
}
