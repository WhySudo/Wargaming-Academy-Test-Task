using System;
using Map;
using UnityEngine;

namespace Blocks
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private bool draggable = true;
        [SerializeField] private int blockType = 0;
        [SerializeField] private Color blockColor;
        public bool Draggable => draggable;
        public int BlockType => blockType;
        public Color BlockColor => blockColor;
        public MapTile TargetTile { get; set; }
    }
}