using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class GiveWeaponsToAgent : MonoBehaviour
    {
        public List<WeaponData> weapons = new List<WeaponData>();

        void Start()
        {
            Agent agent = GetComponentInChildren<Agent>();

            foreach (var weapon in weapons)
            {
                agent.weaponManager.PickUpWeapon(weapon);
            }
        }
    }
}
