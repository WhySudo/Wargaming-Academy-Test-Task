using System.Linq;
using InputControllers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Map
{
    public class MapTilesInputDragging : MonoBehaviour
    {
        public InputController inputController;
        public Camera viewCamera;
        public MapContainer mapContainer;
        public int mouseInputId = 0;

        private MapTile _prevTile;
        private MapTile _lastVisitedTile;

        private void Update()
        {
            if (inputController.IsClickDown(mouseInputId))
            {
                OnDragBegan();
            }
            else if (inputController.IsClickMoved(mouseInputId))
            {
                OnDragging();
            }
            else if (inputController.IsClickUp(mouseInputId))
            {
                OnDragEnded();
            }
        }

        private void OnDragBegan()
        {
            _prevTile = null;
            _lastVisitedTile = null;
            var tile = SearchTileUnderMousePointer();
            if (tile is null) return;
            var available = tile.Occupied && tile.OccupyingBlock.Draggable;
            if (available)
            {
                _prevTile = _lastVisitedTile = tile;
            }

            tile.DragBegan(available);
        }

        private void OnDragging()
        {
            if (_prevTile is null) return;
            var tile = SearchTileUnderMousePointer();
            if (tile == _lastVisitedTile) return;
            _lastVisitedTile = tile;
            if (_prevTile == tile || tile is null) return;
            var availableExchange = !tile.Occupied && mapContainer.ClosestTiles(_prevTile).Contains(tile);
            
            
            if (availableExchange)
            {
                TransferBlockFromTile(_prevTile, tile);
                _prevTile = tile;
            }

            tile.DragBegan(availableExchange);
        }

        private void OnDragEnded()
        {
            if (_prevTile is null) return;
            _prevTile.DragEnded();
        }

        private MapTile SearchTileUnderMousePointer()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return null;
            var cameraRay = viewCamera.ScreenPointToRay(inputController.GetClickScreenPos(mouseInputId));
            if (!Physics.Raycast(cameraRay, out var raycastHit)) return null;
            var tile = mapContainer.SearchTileByGameObject(raycastHit.collider.gameObject);
            return tile;
        }
        private void TransferBlockFromTile(MapTile originTile, MapTile receiveTile)
        {
            originTile.TransferBlock(receiveTile);
            originTile.DragEnded();
            mapContainer.BlockLocationChanged();
        }
    }
}