using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]
public class WeaponInfo : ScriptableObject
{
    public GameObject weaponPrefab;
    public RuntimeAnimatorController playerAnimator;
    public float weaponCooldown;
    public int weaponDamage;
    public float weaponRange;
}
