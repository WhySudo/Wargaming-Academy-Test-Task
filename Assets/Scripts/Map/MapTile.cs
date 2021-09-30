using System;
using Blocks;
using Map.Events;
using UnityEngine;

namespace Map
{
    [RequireComponent(typeof(Collider))]
    public class MapTile : MonoBehaviour
    {
        public readonly DragFromTileBeganEvent DragFromTileBeganEvent = new DragFromTileBeganEvent();
        public readonly DragFromTileEndedEvent DragFromTileEndedEvent = new DragFromTileEndedEvent();
        public readonly OccupyingBlockChangedEvent OccupyingBlockChangedEvent = new OccupyingBlockChangedEvent();

        public Vector2Int coord;

        [Header("Block Placement Information")]
        public Vector3 hoverPosition;

        public Vector3 normalBlockPosition;
        public bool Dragging => _dragging;
        public Vector3 BlockPosition => (_dragging)?(transform.position + hoverPosition):(transform.position + normalBlockPosition);
        public Block OccupyingBlock
        {
            get => _occupyingBlock;
            set
            {
                if (value == _occupyingBlock) return;
                _occupyingBlock = value;
                OccupyingBlockChangedEvent.Invoke(new OccupyingBlockChangedArgs(Occupied));
                
            }
        }
        public bool Occupied => !(_occupyingBlock is null);
        private bool _dragging;
        private Block _occupyingBlock;
        public void TransferBlock(MapTile nextTile)
        {
            var block = _occupyingBlock;
            _occupyingBlock = null;
            block.TargetTile = nextTile;
            nextTile.OccupyingBlock = block;
        }

        public void DragBegan(bool success)
        {
            if (_dragging) return;
            _dragging = success;
            DragFromTileBeganEvent.Invoke(new DragFromTileBeganArgs(success));
        }

        public void DragEnded()
        {
            if (!_dragging) return;
            _dragging = false;
            DragFromTileEndedEvent.Invoke(new DragFromTileEndedArgs());
        }

        private void Update()
        {
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + normalBlockPosition);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + normalBlockPosition, transform.position + hoverPosition);

        }
    }
}