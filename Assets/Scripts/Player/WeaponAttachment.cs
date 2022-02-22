using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachment : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Transform weaponSocket;
    private GameObject currentWeapon;
    void Start()
    {
        currentWeapon = Instantiate(weaponPrefab, weaponSocket.transform.position, weaponSocket.transform.rotation, weaponSocket.transform);
        currentWeapon.transform.parent = weaponSocket.transform;
    }

    
}
