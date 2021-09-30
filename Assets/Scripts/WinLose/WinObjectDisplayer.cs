using System;
using UnityEngine;

namespace WinLose
{
    public class WinObjectDisplayer : MonoBehaviour
    {
        public WinLoseChannel winLoseChannel;
        public GameObject displayedObject;

        private void OnEnable()
        {
            winLoseChannel.WinEvent.AddListener(OnWin);
        }

        private void OnWin()
        {
            displayedObject.SetActive(true);
        }
        
        private void OnDisable()
        {
            winLoseChannel.WinEvent.RemoveListener(OnWin);
        }
    }
}