using Map;
using UnityEngine;

namespace Spawners
{
    //TODO будь проще
    public class MapSpawner : Spawner
    {
        public Transform tileContainer;
        public MapTile mapTilePrefab;
        public MapContainer mapContainer;
        [Header("Map Generation Params")] public Vector2Int mapSize;

        [Header("Offsets")] [Tooltip("отступ между соседними по столбцам клетками")]
        public Vector3 betweenColumnOffset;

        [Tooltip("отступ между соседними по строкам клетками")]
        public Vector3 betweenRowOffset;


        public override void Spawn()
        {
            var tiles = new MapTile[mapSize.x * mapSize.y];
            for (int x = 0; x < mapSize.x; x++)
            {
                for (int y = 0; y < mapSize.y; y++)
                {
                    var tile = Instantiate(mapTilePrefab, tileContainer);
                    tile.coord = new Vector2Int(x, y);
                    tile.transform.position = transform.position + x * betweenColumnOffset + y * betweenRowOffset;
                    tiles[x * mapSize.y + y] = tile;
                }
            }

            mapContainer.SetObjects(tiles);
        }

        private void OnValidate()
        {
            mapSize = new Vector2Int(Mathf.Max(mapSize.x, 0), Mathf.Max(mapSize.y, 0));
        }
    }
}