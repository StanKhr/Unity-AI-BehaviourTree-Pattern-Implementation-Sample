using System;
using UnityEngine;

namespace Demo.Triggers
{
    public class Trigger : MonoBehaviour
    {
        #region Events

        public event Action<GameObject> OnTriggered;

        #endregion

        #region Unity Callbacks

        private void OnTriggerEnter(Collider other)
        {
            OnTriggered?.Invoke(other.gameObject);
        }

        #endregion
    }
}