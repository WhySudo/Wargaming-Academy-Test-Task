using System;
using System.Collections.Generic;
using Blocks;
using Map;
using Map.Zones;
using UnityEngine;

namespace Spawners
{
    public class BlockSpawner : Spawner
    {
        public MapZone spawnZones;
        public MapContainer mapContainer;
        public Block blockPrefab;
        public BlocksContainer blocksContainer;


        public override void Spawn()
        {
            var tileList = spawnZones.Tiles;
            var blocks = new List<Block>();
            foreach (var spawnPoint in tileList)
            {
                var tile = mapContainer.SearchTileByCoords(spawnPoint);
                
                if (tile is null) continue;
                
                var block = Instantiate(blockPrefab, tile.BlockPosition, Quaternion.identity, blocksContainer.transform);
                block.TargetTile = tile;
                tile.OccupyingBlock = block;
                blocks.Add(block);
            }
            blocksContainer.AddObjects(blocks.ToArray());
        }
    }
}