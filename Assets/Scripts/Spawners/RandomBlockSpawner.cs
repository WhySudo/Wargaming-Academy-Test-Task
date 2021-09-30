using System;
using System.Collections.Generic;
using System.Linq;
using Blocks;
using Map;
using Map.Zones;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    
    [Serializable]
    public class SpawnInfo
    {
        public Block prefab;
        public int spawnAmount;
    }
    public class RandomBlockSpawner : Spawner
    {
        public MapZone spawnZones;
        public MapContainer mapContainer;
        public SpawnInfo[] spawnInformation;
        public BlocksContainer blocksContainer;


        public override void Spawn()
        {
            var tileList = new List<Vector2Int>(spawnZones.Tiles);
            var blocks = new List<Block>();
            var returnedBlocks = new List<Block>();
            foreach (var spawnInfo in spawnInformation)
            {
                for (int i = 0; i < spawnInfo.spawnAmount; i++)
                {
                    var block = Instantiate(spawnInfo.prefab, blocksContainer.transform);
                    blocks.Add(block);
                }
            }
            foreach (var spawnPoint in tileList)
            {
                var tile = mapContainer.SearchTileByCoords(spawnPoint);
                if (tile is null) continue;
                var id = Random.Range(0, blocks.Count);
                var block = blocks[id];
                block.TargetTile = tile;
                block.transform.position = tile.BlockPosition;
                tile.OccupyingBlock = block;
                returnedBlocks.Add(block);
                blocks.RemoveAt(id);
            }
            blocksContainer.AddObjects(returnedBlocks.ToArray());
        }
    }
}