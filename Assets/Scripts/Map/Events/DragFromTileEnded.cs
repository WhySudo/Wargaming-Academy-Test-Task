using System;
using UnityEngine.Events;

namespace Map.Events
{
    public class DragFromTileEndedEvent : UnityEvent<DragFromTileEndedArgs>
    {
    }

    [Serializable]
    public class DragFromTileEndedArgs
    {
    }
}