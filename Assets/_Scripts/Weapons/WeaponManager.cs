using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponManager : MonoBehaviour
    {
        public List<AWeaponData> weapons = new List<AWeaponData>();
        public AWeaponData currentWeapon;

        [SerializeField] bool drawGizmo;

        Agent agent;
        SpriteRenderer spriteRenderer;

        public void ToggleWeaponVisibility(bool val)
        {
            spriteRenderer.enabled = val;
        }

        public void HandleWeaponChange()
        {
            AWeaponData weapon = NextWeapon();

            if(weapon != null)
                SetCurrentWeapon(weapon);
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

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
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

        AWeaponData NextWeapon()
        {
            if(weapons.Count() == 1 || currentWeapon == null)
                return null;

            int index = weapons.IndexOf(currentWeapon);
            int nextIndex = index + 1;

            if(nextIndex >= weapons.Count())
                nextIndex = 0;

            return weapons[nextIndex];
        }
    }
}
