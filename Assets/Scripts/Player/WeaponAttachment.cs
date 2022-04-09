using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachment : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Transform weaponSocket;
    private GameObject currentWeapon;
    public string gunTag;
    void Start()
    {
        currentWeapon = Instantiate(weaponPrefab, weaponSocket.transform.position, weaponSocket.transform.rotation, weaponSocket.transform);
        currentWeapon.transform.parent = weaponSocket.transform;
        currentWeapon.gameObject.tag = gunTag;
    }

    
}
