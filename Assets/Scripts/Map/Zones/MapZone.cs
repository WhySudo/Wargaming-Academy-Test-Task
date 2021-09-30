using UnityEngine;
namespace Map.Zones
{
    public abstract class MapZone : ScriptableObject
    {
        public abstract Vector2Int[] Tiles { get; }
    }
}