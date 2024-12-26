using UnityEngine;
using VitalRouter;

namespace DefaultNamespace.View
{
    public abstract class OptionViewBase : MonoBehaviour
    {
        public abstract void Construct(ICommandPublisher commandPublisher, string message);
    }
}