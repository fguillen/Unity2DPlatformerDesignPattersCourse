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
        SpriteRenderer spriteRenderer;

        [SerializeField] bool drawGizmo;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

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
            SetCurrentWeapon(weaponData);
        }

        void SetCurrentWeapon(WeaponData weaponData)
        {
            currentWeapon = weaponData;
            spriteRenderer.sprite = currentWeapon.sprite;
        }

        void OnDrawGizmos()
        {
            // Debug.Log($"OnDrawGizmos({!drawGizmo}, {currentWeapon == null}, {!Application.isPlaying}, {agent == null})");

            if(!drawGizmo || currentWeapon == null || !Application.isPlaying || agent == null)
                return;

            Gizmos.color = Color.red;
            currentWeapon.DrawGizmo(agent);
        }
    }
}
