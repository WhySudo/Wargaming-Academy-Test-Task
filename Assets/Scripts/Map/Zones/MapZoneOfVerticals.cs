using System.Linq;
using UnityEngine;

namespace Map.Zones
{
    [CreateAssetMenu(fileName = "mapZoneOfVerticals", menuName = "Map Zones/Verticals", order = 0)]
    public class MapZoneOfVerticals : MapZone
    {
        public int[] verticals;
        public int verticalMapSize;

        public override Vector2Int[] Tiles => verticals.SelectMany(vertId =>
        {
            var tiles = new Vector2Int[verticalMapSize];
            for (var i = 0; i < verticalMapSize; i++)
            {
                tiles[i] = new Vector2Int(vertId, i);
            }
            return tiles;
        }).ToArray();
    }
}