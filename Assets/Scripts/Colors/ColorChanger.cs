using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    enum Operator
    {
        Add,
        Subtract,
        Set,
    }

    [SerializeField] private Operator operation;
    [SerializeField] private Color color;

    [Header("Objects")]
    [SerializeField] private Renderer[] coloredObjects;

    private void Awake()
    {
        SetOwnColor(color);
    }
    private void OnValidate()
    {
        foreach (Renderer renderer in coloredObjects)
        {
            try
            {
                Material material = new Material(renderer.sharedMaterial);
                material.color = color;
                renderer.material = material;
            }
            catch { }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.TryGetComponent(out ColorAgent agent))
            {
                ChangeColor(agent);
            }
        }
    }

    private void ChangeColor(ColorAgent agent)
    {
        switch (operation)
        {
            case Operator.Add:
                agent.AddColor(color);
                break;
            case Operator.Subtract:
                agent.SubtractColor(color);
                break;
            case Operator.Set:
                agent.SetColor(color);
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
