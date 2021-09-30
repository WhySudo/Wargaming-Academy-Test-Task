using System.Linq;
using UnityEngine;

namespace InputControllers
{
    public class MobileInputController : InputController
    {
        public override int[] GetAllClickProviders()
        {
            return Enumerable.Range(0, Input.touchCount).ToArray();
        }
        public override bool IsClickUp(int inputId)
        {
            return Input.GetTouch(inputId).phase == TouchPhase.Ended;
        }

        public override bool IsClickMoved(int inputId)
        {
            return Input.GetTouch(inputId).phase == TouchPhase.Moved;
        }

        public override bool IsClickDown(int inputId)
        {
            return Input.GetTouch(inputId).phase == TouchPhase.Began;
        }

        public override Vector3 GetClickScreenPos(int inputId)
        {
            return Input.GetTouch(inputId).position;
        }

        public override int GetClickUniqueId(int inputId)
        {
            return Input.GetTouch(inputId).fingerId;
        }
    }
}