using System;
using UnityEngine.Events;

namespace Map.Events
{
    public class DragFromTileBeganEvent : UnityEvent<DragFromTileBeganArgs>
    {
    }

    [Serializable]
    public class DragFromTileBeganArgs
    {
        public bool success;

        public DragFromTileBeganArgs(bool success)
        {
            this.success = success;
        }
    }
}