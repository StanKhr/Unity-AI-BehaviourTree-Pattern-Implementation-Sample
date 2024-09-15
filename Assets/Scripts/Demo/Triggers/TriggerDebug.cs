using UnityEngine;

namespace Demo.Triggers
{
    public class TriggerDebug : MonoBehaviour
    {
        #region Unity Callbacks

        private void Awake()
        {
            if (!TryGetComponent<Trigger>(out var trigger))
            {
                return;
            }

            trigger.OnTriggered += context => Debug.Log($"{context.name} triggers {name}.");
        }

        #endregion
    }
}