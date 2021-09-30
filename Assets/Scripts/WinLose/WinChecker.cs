using System;
using System.Linq;
using Map;
using Map.Events;
using Map.Zones;
using UnityEngine;

namespace WinLose
{
    public class WinChecker : MonoBehaviour
    {
        public WinLoseChannel winLoseChannel;
        public MapZone[] zonesToCheck;
        public MapContainer mapContainer;

        private void OnEnable()
        {
            mapContainer.BlocksLocationChangedEvent.AddListener(OnBlocksLocationChanged);
        }

        private void OnBlocksLocationChanged(BlocksLocationChangedArgs arg0)
        {
            CheckWin();
        }

        private void OnDisable()
        {
            mapContainer.BlocksLocationChangedEvent.RemoveListener(OnBlocksLocationChanged);
        }

        private void CheckWin()
        {
            var winCond = CheckWinCondition(zonesToCheck, mapContainer);
            if (!winCond) return;
            winLoseChannel.Win();
        }

        private static bool CheckWinCondition(MapZone[] zones, MapContainer container)
        {
            return zones.All(zone => CheckForSameBlocksInZone(zone, container));
        }

        private static bool CheckForSameBlocksInZone(MapZone zone, MapContainer container)
        {
            var tiles = zone.Tiles.Select(container.SearchTileByCoords).ToArray();
            var idSet = false;
            var id = 0;
            foreach (var tile in tiles)
            {
                if (tile.OccupyingBlock == null)
                {
                    return false;
                }

                if (!idSet)
                {
                    idSet = true;
                    id = tile.OccupyingBlock.BlockType;
                }
                else
                {
                    if (tile.OccupyingBlock.BlockType != id)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}