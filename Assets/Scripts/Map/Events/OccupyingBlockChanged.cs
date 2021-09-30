using System;
using UnityEngine.Events;

namespace Map.Events
{
    public class OccupyingBlockChangedEvent : UnityEvent<OccupyingBlockChangedArgs>
    {
    }

    [Serializable]
    public class OccupyingBlockChangedArgs
    {
        public bool newOccupationStatus;

        public OccupyingBlockChangedArgs(bool newOccupationStatus)
        {
            this.newOccupationStatus = newOccupationStatus;
        }
    }
}