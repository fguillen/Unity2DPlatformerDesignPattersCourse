using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  PlayerSpawn
{
    public class PlayerSpawnManager : MonoBehaviour
    {
        SpawnPoint currentSpawnPoint;
        [SerializeField] Agent agent;

        public static PlayerSpawnManager instance;

        void Awake()
        {
            instance = this;
        }

        public void SetCurrentSpawnPoint(SpawnPoint spawnPoint)
        {
            currentSpawnPoint = spawnPoint;
        }

        public void SpawnPlayer()
        {
            agent.transform.position = currentSpawnPoint.transform.position;
        }
    }
}
