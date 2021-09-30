using UnityEngine;

namespace Map.Zones
{
    [CreateAssetMenu(fileName = "mapZoneArray", menuName = "Map Zones/Array", order = 0)]
    public class MapZoneOfArray : MapZone
    {
        public Vector2Int[] points;
        public override Vector2Int[] Tiles => points;
    }
}