using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewThrowableWeaponData", menuName = "Weapons/Throwable")]
    public class WeaponDataThrowable : AWeaponData
    {
        [SerializeField] public float range = 10f;
        [SerializeField] public float speed = 2f;
        [SerializeField] GameObject weaponPrefab;

        public override bool CanBeUsed(Agent agent)
        {
            return true;
        }

        public override void Attack(Agent agent)
        {
            GameObject weaponObject = Instantiate(weaponPrefab, agent.weaponManager.transform.position, Quaternion.identity);
            weaponObject.GetComponent<ThrowableWeapon>().Initialize(agent, this);
        }
    }
}
