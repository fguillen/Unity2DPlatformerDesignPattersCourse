using UnityEngine;
using DG.Tweening;

namespace WeaponSystem
{
    public class ThrowableWeapon : MonoBehaviour
    {
        Rigidbody2D rb2d;
        Agent agent;
        WeaponDataThrowable data;
        Vector2 direction;
        Vector2 startPosition;

        void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            startPosition = transform.position;
        }

        void Update()
        {
            CheckRange();
        }

        public void Initialize(Agent agent, WeaponDataThrowable data)
        {
            this.agent = agent;
            this.data = data;
            this.direction = Direction(agent);

            rb2d.velocity = direction * data.speed;

            transform.DOLocalRotate(
                new Vector3(0, 0, 360 * -agent.movementData.movementLastDirection.x),
                0.5f,
                RotateMode.FastBeyond360
            ).SetRelative(true).SetEase(Ease.Linear);
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log($"ThrowableWeapon.OnTriggerEnter2D({collider.gameObject.name})");

            if(
                collider.gameObject != agent.damageManager.gameObject &&
                Utils.InLayerMask(collider.gameObject.layer, data.hittableMask)
            )
                Hit(collider);
        }

        void Hit(Collider2D collider)
        {
            Debug.Log($"ThrowableWeapon Hit something ({collider.gameObject.name})");

            foreach (var hittable in collider.GetComponents<IHittable>())
            {
                Debug.Log($"Sending Hit");
                hittable.GetHit(data.damage, transform.position);
            }

            DestroyObject();
        }

        void CheckRange()
        {
            if((startPosition - (Vector2)transform.position).magnitude > data.range)
                DestroyObject();
        }

        Vector2 Direction(Agent agent)
        {
            return new Vector2(agent.movementData.movementLastDirection.x, 0f);
        }

        void DestroyObject()
        {
            DOTween.Kill(transform);
            Destroy(gameObject);
        }
    }
}
