using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public abstract class WeaponData : ScriptableObject, IEquatable<WeaponData>
    {
        public string weaponName;
        public int damage;
        public Sprite sprite;
        public AudioClip soundEffect;

        public bool Equals(WeaponData other)
        {
            return weaponName == other.weaponName;
        }

        public abstract bool CanBeUsed(Agent agent);
        public abstract void Attack(Agent agent);
        public abstract void DrawGizmo(Agent agent);
    }
}
