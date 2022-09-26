using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  PlayerSpawn
{
    public class SpawnPoint : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("SpawnPoint.OnTriggerEnter2D()");

            if(collider.gameObject.CompareTag("Player"))
                PlayerSpawnManager.instance.SetCurrentSpawnPoint(this);
        }
    }
}
