using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponManager : MonoBehaviour
    {
        public List<AWeaponData> weapons = new List<AWeaponData>();
        public AWeaponData currentWeapon;
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

        public void AddWeapon(AWeaponData weaponData)
        {
            weapons.Add(weaponData);
        }

        public void PickUpWeapon(AWeaponData weaponData)
        {
            AddWeapon(weaponData);
            SetCurrentWeapon(weaponData);
        }

        void SetCurrentWeapon(AWeaponData weaponData)
        {
            currentWeapon = weaponData;
            spriteRenderer.sprite = currentWeapon.sprite;
        }

        void OnDrawGizmos()
        {
            // Debug.Log($"OnDrawGizmos({!drawGizmo}, {currentWeapon == null}, {!Application.isPlaying}, {agent == null})");

            if(!drawGizmo || currentWeapon == null || agent == null)
                return;

            Gizmos.color = Color.red;
            currentWeapon.DrawGizmo(agent);
        }
    }
}
