using System;
using System.Linq;
using Map.Events;
using UnityEngine;

namespace Map
{
    /// <summary>
    /// Контейнер клеток карты
    /// </summary>
    public class MapContainer : ObjectContainer<MapTile>
    {
        public readonly BlocksLocationChangedEvent BlocksLocationChangedEvent = new BlocksLocationChangedEvent();
        public MapTile SearchTileByCoords(Vector2Int coords)
        {
            return entities.FirstOrDefault(tile => tile.coord == coords);
        }

    
        public MapTile[] ClosestTiles(MapTile mapTile)
        {
            return entities.Where(tile => tile != mapTile && AbsoluteDifference(tile.coord, mapTile.coord) == 1)
                .ToArray();
        }

        public void BlockLocationChanged()
        {
            BlocksLocationChangedEvent.Invoke(new BlocksLocationChangedArgs());
        }
        
        private static int AbsoluteDifference(Vector2Int a, Vector2Int b)
        {
            return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
        }
    }
}