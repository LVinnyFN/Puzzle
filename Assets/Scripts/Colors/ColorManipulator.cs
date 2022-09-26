using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorManipulator : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent<Color> onEnter;
    public UnityEvent<Color> onEnterWithColor;
    public UnityEvent<Color> onExit;
    public UnityEvent<Color> onExitWithColor;
    [Space]
    [SerializeField] protected Color manipulatedColor;
    [SerializeField] protected Renderer[] coloredObjects;

    private void OnValidate()
    {
        foreach (Renderer renderer in coloredObjects)
        {
            try
            {
                Material material = new Material(renderer.sharedMaterial);
                material.color = manipulatedColor;
                renderer.material = material;
            }
            catch { }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TruckLoad") && other.TryGetComponent(out ColorAgent agent))
        {
            onEnter?.Invoke(manipulatedColor);
            OnAgentEnter();

            if (agent.MyColor == manipulatedColor)
            {
                onEnterWithColor?.Invoke(manipulatedColor);
                OnAgentEnterWithColor();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TruckLoad") && other.TryGetComponent(out ColorAgent agent))
        {
            onExit?.Invoke(manipulatedColor);
            OnAgentExit();

            if(agent.MyColor == manipulatedColor)
            {
                onExitWithColor?.Invoke(manipulatedColor);
                OnAgentExitWithColor();
            }
        }
    }

    public virtual void OnAgentEnter() { }
    public virtual void OnAgentExit() { }
    public virtual void OnAgentEnterWithColor() { }
    public virtual void OnAgentExitWithColor() { }
}
