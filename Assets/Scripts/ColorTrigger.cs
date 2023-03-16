using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LVin.ColorPzl.Core
{
    public class ColorTrigger : ColorManipulator
    {
        [Header("Events")]
        public UnityEvent<Color> onEnter;
        public UnityEvent<Color> onEnterRightColor;
        public UnityEvent<Color> onExit;
        public UnityEvent<Color> onExitRightColor;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("TruckLoad") && other.TryGetComponent(out ColorAgent agent))
            {
                onEnter?.Invoke(agent.MyColor);
                OnAgentEnter();

                if (agent.MyColor == manipulatedColor)
                {
                    onEnterRightColor?.Invoke(agent.MyColor);
                    OnAgentEnterWithColor();
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("TruckLoad") && other.TryGetComponent(out ColorAgent agent))
            {
                onExit?.Invoke(agent.MyColor);
                OnAgentExit();

                if (agent.MyColor == manipulatedColor)
                {
                    onExitRightColor?.Invoke(agent.MyColor);
                    OnAgentExitWithColor();
                }
            }
        }
        public virtual void OnAgentEnter() { }
        public virtual void OnAgentExit() { }
        public virtual void OnAgentEnterWithColor() { }
        public virtual void OnAgentExitWithColor() { }
    }
}