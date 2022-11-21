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
    private void Awake()
    {
        SetOwnColor(manipulatedColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TruckLoad") && other.TryGetComponent(out ColorAgent agent))
        {
            onEnter?.Invoke(agent.MyColor);
            OnAgentEnter();

            if (agent.MyColor == manipulatedColor)
            {
                onEnterWithColor?.Invoke(agent.MyColor);
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

            if(agent.MyColor == manipulatedColor)
            {
                onExitWithColor?.Invoke(agent.MyColor);
                OnAgentExitWithColor();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = manipulatedColor;
        foreach(Renderer obj in coloredObjects)
        {
            Gizmos.DrawWireMesh(obj.GetComponent<MeshFilter>().sharedMesh, obj.transform.position, obj.transform.rotation, obj.transform.localScale);
        }
    }


    private void SetOwnColor(Color color)
    {
        foreach (Renderer renderer in coloredObjects)
        {
            renderer.material.color = color;
        }
    }

    public virtual void OnAgentEnter() { }
    public virtual void OnAgentExit() { }
    public virtual void OnAgentEnterWithColor() { }
    public virtual void OnAgentExitWithColor() { }
}
