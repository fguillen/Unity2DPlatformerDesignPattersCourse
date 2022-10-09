using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IHittable
    {
        void GetHit(int damage, Vector2 point);
    }
}
