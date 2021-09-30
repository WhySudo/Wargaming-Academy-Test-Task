using UnityEngine;

namespace InputControllers
{
    public abstract class InputController : MonoBehaviour
    {
        public abstract int[] GetAllClickProviders();
        public abstract bool IsClickUp(int inputId);
        public abstract bool IsClickMoved(int inputId);
        public abstract bool IsClickDown(int inputId);
        public abstract Vector3 GetClickScreenPos(int inputId);
        public abstract int GetClickUniqueId(int inputId);

    }
}