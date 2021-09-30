using System;
using Map;
using UnityEngine;

namespace Blocks
{
    [RequireComponent(typeof(Block))]
    public class BlockMovement : MonoBehaviour
    {
        [SerializeField]
        private float smoothTime = 0.3f;
        private Block _referencedBlock;

        private Vector3 _velocity = Vector3.zero;
        private Vector3 ExpectedPosition => _referencedBlock.TargetTile.BlockPosition;

        private void Awake()
        {
            _referencedBlock = GetComponent<Block>();
        }

        private void Update()
        {
            if(_referencedBlock.TargetTile is null) return;
            transform.position = Vector3.SmoothDamp(transform.position, ExpectedPosition, ref _velocity, smoothTime);
        }
    }
}