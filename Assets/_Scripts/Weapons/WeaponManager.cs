using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponManager : MonoBehaviour
    {
        public List<WeaponData> weapons = new List<WeaponData>();
        public WeaponData currentWeapon;
        Agent agent;

        [SerializeField] bool drawGizmo;

        public void Initialize(Agent agent)
        {
            this.agent = agent;
        }

        public bool CanAttack()
        {
            return (currentWeapon != null && currentWeapon.CanBeUsed(agent));
        }

        public void Attack()
        {
            currentWeapon.Attack(agent);
        }

        public void AddWeapon(WeaponData weaponData)
        {
            weapons.Add(weaponData);
        }

        public void PickUpWeapon(WeaponData weaponData)
        {
            AddWeapon(weaponData);
            currentWeapon = weaponData;
        }

        void OnDrawGizmos()
        {
            if(!drawGizmo || currentWeapon == null || agent == null)
                return;

            Gizmos.color = Color.red;
            currentWeapon.DrawGizmo(agent);
        }
    }
}
