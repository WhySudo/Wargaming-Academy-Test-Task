using System;
using Map.Events;
using UnityEngine;

namespace Map
{
    [RequireComponent(typeof(MapTile))]
    public class MapTileEventsVisualizer : MonoBehaviour
    {
        public MeshRenderer tileViewRenderer;
        public Color draggingColor;
        private MapTile _referencedTile;
        private Color _sourceColor;
        private void Awake()
        {
            _referencedTile = GetComponent<MapTile>();
            _sourceColor = tileViewRenderer.material.color;
        }

        private void OnEnable()
        {
            _referencedTile.DragFromTileBeganEvent.AddListener(OnTileDraggingBegan);
            _referencedTile.DragFromTileEndedEvent.AddListener(OnTileDraggingEnded);
        }

        private void OnTileDraggingEnded(DragFromTileEndedArgs arg0)
        {
            tileViewRenderer.material.color = _sourceColor;
        }

        private void OnTileDraggingBegan(DragFromTileBeganArgs arg0)
        {
            if (!arg0.success) return;
            tileViewRenderer.material.color = draggingColor;
        }
        private void OnDisable()
        {
            _referencedTile.DragFromTileBeganEvent.RemoveListener(OnTileDraggingBegan);
            _referencedTile.DragFromTileEndedEvent.RemoveListener(OnTileDraggingEnded);
        }
    }
}