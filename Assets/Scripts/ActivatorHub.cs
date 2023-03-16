using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LVin.Logic
{
    public class ActivatorHub : MonoBehaviour
    {
        public Activator[] activators;
        public UnityEvent<bool> onSwitchState = new UnityEvent<bool>();
        public bool state { get; private set; }
        public int activeActivators;

        private void Awake()
        {            
            foreach (Activator activator in activators)
            {
                activeActivators += activator.state ? 1 : 0;
                activator.onSwitchState.AddListener(OnActivatorChange);
            }           
        }

        private void OnActivatorChange(bool newValue)
        {
            activeActivators += newValue ? 1 : -1; 
            if (activeActivators == activators.Length) Activate();
            else Deactivate();
        }

        private void Activate()
        {
            if (!state)
            {
                state = true;
                onSwitchState?.Invoke(true);
            }
        }
        private void Deactivate()
        {
            if (state)
            {
                state = false;
                onSwitchState?.Invoke(false);
            }
        }
    }
}