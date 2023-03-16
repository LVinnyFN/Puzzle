using UnityEngine;

namespace LVin.ColorPzl.Core
{
    public class ColorChanger : ColorManipulator
    {
        enum Operator
        {
            Add,
            Subtract,
            Set,
        }

        [SerializeField] private Operator operation;

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
    }
}