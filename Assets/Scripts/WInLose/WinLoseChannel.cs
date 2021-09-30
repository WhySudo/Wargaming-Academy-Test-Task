using UnityEngine;

namespace WInLose
{
    [CreateAssetMenu(fileName = "winLoseChannel", menuName = "Channels/Winlose Channel", order = 0)]
    public class WinLoseChannel : ScriptableObject
    {
        public readonly WinEvent WinEvent = new WinEvent();

        public void Win()
        {
            WinEvent.Invoke();
        }
    }
}