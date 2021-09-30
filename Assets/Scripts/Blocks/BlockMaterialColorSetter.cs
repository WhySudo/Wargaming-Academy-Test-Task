using System;
using UnityEngine;

namespace Blocks
{
    [RequireComponent(typeof(Block))]
    public class BlockMaterialColorSetter : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer meshRenderer;
        private Block _block;
        private void Start()
        {
            _block = GetComponent<Block>();
            meshRenderer.material.color = _block.BlockColor;
        }
    }
}