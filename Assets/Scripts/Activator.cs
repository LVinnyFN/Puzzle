using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LVin.Logic
{
    public class Activator : MonoBehaviour
    {
        public UnityEvent<bool> onSwitchState = new UnityEvent<bool>();
        public bool state { get; protected set; }
        public bool debugBool;

        public virtual void Activate()
        {
            if (!state)
            {
                state = true;
                onSwitchState?.Invoke(true);
            }
        }
        public virtual void Deactivate()
        {
            if (state)
            {
                debugBool = state = false;
                onSwitchState?.Invoke(false);
            }
        }
    }
}
