using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sensors
{
    public class BoxSensor : MonoBehaviour
    {
        [SerializeField] bool drawGizmos;
        [SerializeField] Color gizmosColor = Color.red;
        [SerializeField] float gizmosSize = 0.2f;
        [SerializeField] LayerMask objectiveLayerMask;
        [SerializeField] List<string> tags;
        [SerializeField] bool selfCheck;

        public List<Collider2D> hits { get; private set; }
        public UnityEvent<List<Collider2D>> OnHitDetected;
        public UnityEvent OnHitUndetected;

        Collider2D[] collidersFound;
        bool hasHit;
        Collider2D theCollider;
        ContactFilter2D contactFilter;

        public bool HasHit()
        {
            CheckHit();
            return hasHit;
        }

        void Awake()
        {
            theCollider = GetComponent<Collider2D>();
            collidersFound = new Collider2D[10];
            hits = new List<Collider2D>();

            contactFilter = new ContactFilter2D();
            contactFilter.SetLayerMask(objectiveLayerMask);
            contactFilter.useTriggers = true;
        }

        void Update()
        {
            if(selfCheck)
                CheckHit();
        }

        void CheckHit()
        {
            contactFilter.SetLayerMask(objectiveLayerMask);
            int num = theCollider.OverlapCollider(contactFilter, collidersFound);

            hits.Clear();
            for (int i = 0; i < num; i++)
                if(CheckTags(collidersFound[i]))
                    hits.Add(collidersFound[i]);

            if(num > 0)
            {
                if(!hasHit)
                    HitDetected();
            }
            else
            {
                if(hasHit)
                    HitUndetected();
            }
        }

        void HitDetected()
        {
            hasHit = true;
            OnHitDetected?.Invoke(hits);
        }

        void HitUndetected()
        {
            hasHit = true;
            OnHitUndetected?.Invoke();
        }

        bool CheckTags(Collider2D collider)
        {
            if(tags.Count == 0)
                return true;

            return tags.Contains(collider.tag);
        }

        void OnDrawGizmos()
        {
            if(!drawGizmos)
                return;

            Gizmos.color = gizmosColor;

            if(hasHit)
                DrawGizmosHits();
        }

        void DrawGizmosHits()
        {
            foreach (var hit in hits)
            {
                Gizmos.DrawSphere(hit.transform.position, gizmosSize);
            }
        }
    }
}
