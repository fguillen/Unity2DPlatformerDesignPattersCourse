using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewMeleeWeaponData", menuName = "Weapons/Melee")]
    public class WeaponDataMelee : WeaponData
    {
        public float range = 2f;

        public override bool CanBeUsed(Agent agent)
        {
            return agent.groundDetector.isGrounded;
        }

        public override void Attack(Agent agent)
        {
            Debug.Log("WeaponDataMelee.Attack()");

            RaycastHit2D hit =
                Physics2D.Raycast(
                    agent.weaponManager.transform.position,
                    Direction(agent),
                    range,
                    hittableMask
                );

            if(hit.collider != null)
            {
                foreach (var hittable in hit.collider.GetComponents<IHittable>())
                {
                    hittable.GetHit(damage);
                }
            }
        }

        public override void DrawGizmo(Agent agent)
        {
            // Debug.Log($"DrawGizmo: [{agent.weaponManager.transform.position}], [{agent.weaponManager.transform.position + (Vector3)(Direction(agent) * range)}]");
            Gizmos.DrawLine(
                agent.weaponManager.transform.position,
                agent.weaponManager.transform.position + (Vector3)(Direction(agent) * range)
            );
        }

        Vector2 Direction(Agent agent)
        {
            return new Vector2(agent.movementData.horizontalMovementDirection, 0f);
        }
    }
}
