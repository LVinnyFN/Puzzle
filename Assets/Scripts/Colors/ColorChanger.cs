using UnityEngine;

public class ColorChanger : ColorManipulator
{
    enum Operator
    {
        Add,
        Subtract,
        Set,
    }

    [SerializeField] private Operator operation;

    private void Awake()
    {
        SetOwnColor(manipulatedColor);
    }
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
            ChangeColor(agent);
        }
    }

    private void ChangeColor(ColorAgent agent)
    {
        switch (operation)
        {
            case Operator.Add:
                agent.AddColor(manipulatedColor);
                break;
            case Operator.Subtract:
                agent.SubtractColor(manipulatedColor);
                break;
            case Operator.Set:
                agent.SetColor(manipulatedColor);
                break;
        }
    }

    private void SetOwnColor(Color color)
    {
        foreach(Renderer renderer in coloredObjects)
        {
            renderer.material.color = color;
        }
    }
}
