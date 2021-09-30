using UnityEngine;

namespace InputControllers
{
    public class PCInputController : InputController
    {
        public override int[] GetAllClickProviders()
        {
            return new[] {0};
        }

        public override bool IsClickUp(int inputId)
        {
            return Input.GetMouseButtonUp(0);
        }

        public override bool IsClickMoved(int inputId)
        {
            return Input.GetMouseButton(0);
        }

        public override bool IsClickDown(int inputId)
        {
            return Input.GetMouseButtonDown(0);
        }

        public override Vector3 GetClickScreenPos(int inputId)
        {
            return Input.mousePosition;
        }

        public override int GetClickUniqueId(int inputId)
        {
            return 0;
        }
    }
}