using System;
using UnityEngine;

namespace Spawners
{
    public class MapInitializer : MonoBehaviour
    {
        public Spawner[] spawners;
        private void Start()
        {
            SpawnAllSpawners();
        }

        private void SpawnAllSpawners()
        {
            foreach (var spawner in spawners)
            {
                spawner.Spawn();
            }
        }
    }
}